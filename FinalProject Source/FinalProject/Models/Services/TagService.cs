using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Services
{
    public class TagService
    {
        private BloggingContext context;

        public TagService(BloggingContext ctx) => context = ctx;

        public IEnumerable<Tag> GetTags() => context.Tags;

        public Tag GetTagById(long id) => context.Tags.FirstOrDefault(t => t.Id == id);

        public void SaveTag(Tag tag)
        {
            if (!context.Tags.Any(t => t.Tagname == tag.Tagname))
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void UpdateTag(Tag tag)
        {
            context.Tags.Update(tag);
            context.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            context.Tags.Remove(tag);
            context.SaveChanges();
        }
    }
}
