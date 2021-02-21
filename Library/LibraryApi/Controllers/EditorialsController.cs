using LibraryApi.Data.Editorial;
using LibraryApi.Entities;
using LibraryApi.Entities.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialData editorialData;
        public EditorialsController(IEditorialData editorialData)
        {
            this.editorialData = editorialData;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(editorialData.GetEditorials());
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
                var editorial = editorialData.GetEditorial(id);
                if (editorial != null)
                {
                    return Ok(editorial);
                }
                return NotFound($"editorial with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] RequestEditorial editorial)
        {
            try
            {
                editorialData.AddEditorial(editorial);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{editorial.Id}",
                    editorial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] RequestEditorial editorial)
        {
            try
            {
                var existingEditorial = editorialData.GetEditorial(editorial.Id);
                if (existingEditorial != null)
                    editorialData.EditEditorial(editorial);
                return Ok(editorial);
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
                var editorial = editorialData.GetEditorial(id);
                if (editorial != null)
                {
                    editorialData.DeleteEditorial(editorial);
                    return Ok();
                }
                return NotFound($"editorial with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
