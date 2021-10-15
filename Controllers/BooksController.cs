using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookSevice _bookSevice;
        public BooksController(BookSevice bookSevice)
        {
            _bookSevice = bookSevice;
        }


        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookSevice.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookSevice.GetBookById(id);
            return Ok(book);
        }

        [HttpGet("get-book-author-by-id/{id}")]
        public IActionResult GetBookAuthorById(int id)
        {
            var bookAuthor = _bookSevice.GetBookAuthorById(id);
            return Ok(bookAuthor);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookSevice.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody] BookVM book)
        {
           var updateBook = _bookSevice.UpdateBookById(id,book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookSevice.DeleteBookById(id);
            return Ok();
        }
    }
}
