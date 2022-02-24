using FinalProject.Models;
using FinalProject.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private CommentService commentService;

        public CommentsController(CommentService service) => commentService = service;

        [HttpGet]
        public IEnumerable<Comment> GetComments() => commentService.GetComments();

        [HttpGet("{id}")]
        public Comment GetComment(long id) => commentService.GetCommentById(id);

        [HttpPost]
        public void SaveComment([FromBody] Comment comment) => commentService.SaveComment(comment);

        [HttpPut]
        public void UpdateComment([FromBody] Comment comment) => commentService.UpdateComment(comment);

        [HttpDelete("{id}")]
        public void DeleteComment(long id)
        {
            var commentToDelete = commentService.GetCommentById(id);
            if (commentToDelete != null)
                commentService.DeleteComment(commentToDelete);
        }
    }
}
