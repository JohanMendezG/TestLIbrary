using LibraryApi.Data.Book;
using LibraryApi.Entities.RequestModel;
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
    public class BooksController : ControllerBase
    {
        private readonly IBookData bookData;
        public BooksController(IBookData bookData)
        {
            this.bookData = bookData;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(bookData.GetBooks());
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
                var book = bookData.GetBook(id);
                if (book != null)
                {
                    return Ok(book);
                }
                return NotFound($"Book with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] RequestBook book)
        {
            try
            {
                bookData.AddBook(book);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{book.Id}",
                    book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] RequestBook book)
        {
            try
            {
                var existingBook = bookData.GetBook(book.Id);
                if (existingBook != null)
                    bookData.EditBook(book);
                return Ok(book);
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
                var book = bookData.GetBook(id);
                if (book != null)
                {
                    bookData.DeleteBook(book);
                    return Ok();
                }
                return NotFound($"Book with Id: {id} was not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
