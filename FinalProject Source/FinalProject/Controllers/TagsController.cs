using FinalProject.Models;
using FinalProject.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private TagService tagService;

        public TagsController(TagService service) => tagService = service;

        [HttpGet]
        public IEnumerable<Tag> GetTags() => tagService.GetTags();

        [HttpGet("{id}")]
        public Tag GetTag(long id) => tagService.GetTagById(id);

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void SaveTag([FromBody] Tag tag) => tagService.SaveTag(tag);

        [HttpPut]
        public void UpdateTag([FromBody] Tag tag) => tagService.UpdateTag(tag);

        [HttpDelete("{id}")]
        public void DeleteTag(long id)
        {
            var tagToDelete = tagService.GetTagById(id);
            if (tagToDelete != null)
                tagService.DeleteTag(tagToDelete);
        }
    }
}
