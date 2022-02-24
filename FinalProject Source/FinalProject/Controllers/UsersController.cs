using FinalProject.Models;
using FinalProject.Models.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService userService;
        private RoleService roleService;

        public UsersController(UserService uService, RoleService rService)
        {
            userService = uService;
            roleService = rService;
        }

        [HttpGet]
        [Route("authenticate")]
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Either username or password is incorrect.");

            User user = userService.GetUserByUsername(username);
            if (user is null)
                throw new AuthenticationException("User not found.");

            if (user.Password != password)
                throw new AuthenticationException("Password entered is incorrect.");

            Role role = roleService.GetRoleById(user.RoleId ?? 3);

            List<Claim> claims = new()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Rolename)
            };

            ClaimsIdentity claimsIdentity = new(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return user;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<User> GetUsers() => userService.GetUsers();

        [HttpGet("{id}")]
        public User GetUser(long? id) => userService.GetUserById(id);

        [HttpPost]
        public void SaveUser([FromBody] User user)
        {
            if (user.RoleId == null) user.RoleId = 3;
            userService.SaveUser(user);
        }

        [HttpPut]
        public void UpdateUser([FromBody] User user) => userService.UpdateUser(user);

        [HttpDelete("{id}")]
        public void DeleteUser(long? id)
        {
            var userToDelete = userService.GetUserById(id);
            if (userToDelete != null)
                userService.DeleteUser(userToDelete);
        }
    }
}