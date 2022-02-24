using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Models.Services
{
    public class PostService
    {
        private BloggingContext context;

        public PostService(BloggingContext ctx) => context = ctx;

        public IEnumerable<Post> GetPosts() => context.Posts;

        public IEnumerable<Post> GetPostsByAuthor(long id)
        {
            if (!context.Users.Any(u => u.Id == id)) 
                return new List<Post>();

            return context.Posts.Where(p => p.UserId == id);
        }

        public void SavePost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Posts.Update(post);
            context.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }
    }
}
