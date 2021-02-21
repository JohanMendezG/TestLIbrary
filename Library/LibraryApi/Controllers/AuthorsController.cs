using LibraryApi.AuthorData;
using LibraryApi.Context;
using LibraryApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorData authorData;
        public AuthorsController(IAuthorData authorData)
        {
            this.authorData = authorData;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(authorData.GetAuthors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var author = authorData.GetAuthor(id);
                if (author != null)
                {
                    return Ok(author);
                }
                return NotFound($"Author with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Authors author)
        {
            try
            {
                authorData.AddAuthor(author);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{author.Id}",
                    author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] Authors author)
        {
            try
            {
                var existingAuthor = authorData.GetAuthor(author.Id);
                if (existingAuthor != null)
                    authorData.EditAuthor(author);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var author = authorData.GetAuthor(id);
                if (author != null)
                {
                    authorData.DeleteAuthor(author);
                    return Ok();
                }
                return NotFound($"Author with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
