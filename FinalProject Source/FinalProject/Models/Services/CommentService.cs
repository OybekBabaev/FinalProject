using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Services
{
    public class CommentService
    {
        private BloggingContext context;

        public CommentService(BloggingContext ctx) => context = ctx;

        public IEnumerable<Comment> GetComments() => context.Comments;

        public Comment GetCommentById(long id) => 
            context.Comments.FirstOrDefault(c => c.Id == id);

        public void SaveComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            context.Comments.Update(comment);
            context.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
