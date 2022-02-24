using FinalProject.Models;
using FinalProject.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private PostService postService;

        public PostsController(PostService service) => postService = service;

        [HttpGet]
        public IEnumerable<Post> GetPosts() => postService.GetPosts();

        [HttpGet("{id}")]
        public IEnumerable<Post> GetPostsByAuthor(long id) => postService.GetPostsByAuthor(id);

        [HttpPost]
        public void SavePost([FromBody] Post post) => postService.SavePost(post);

        [HttpPut]
        public void UpdatePost([FromBody] Post post) => postService.UpdatePost(post);

        [HttpDelete]
        public void DeletePost(Post post) => postService.DeletePost(post);
    }
}
