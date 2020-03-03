using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.DBModels;
using SampleWebAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpPut]
        public ActionResult Put([FromBody]BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _bookService.UpdateBook(bookModel);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var result =  await _bookService.DeleteBook(id);
           // if (result)
                return Ok();
        }
    }
}