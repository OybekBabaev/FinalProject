using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Services
{
    public class PostTagService
    {
        private BloggingContext context;

        public PostTagService(BloggingContext ctx) => context = ctx;

        public IEnumerable<PostTag> GetPostTags() => context.PostTags;

        public PostTag GetPostTagById(long id) =>
            context.PostTags.FirstOrDefault(pt => pt.Id == id);

        public void SavePostTag(PostTag postTag)
        {
            if (context.Posts.Any(p => p.Id == postTag.PostId)
                && context.Tags.Any(t => t.Id == postTag.TagId))
            {
                context.PostTags.Add(postTag);
                context.SaveChanges();
            }
        }

        public void UpdatePostTag(PostTag postTag)
        {
            context.PostTags.Update(postTag);
            context.SaveChanges();
        }

        public void DeletePostTag(PostTag postTag)
        {
            context.PostTags.Remove(postTag);
            context.SaveChanges();
        }
    }
}
