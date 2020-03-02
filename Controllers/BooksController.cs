using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.DBModels;
using SampleWebAPI.Repository;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> Get()
        {
            var items = _bookService.GetLatestBooks();
            return Ok(items);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BookModel>> Get(int id)
        {
            var items = _bookService.GetBook(id);
            return Ok(items);
        }
        [HttpGet("search/{id}")]
        public ActionResult<IEnumerable<BookModel>> Search(string id)
        {
            var items = _bookService.GetBook(id);
            return Ok(items);
        }
        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _bookService.AddNewBook(bookModel);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}