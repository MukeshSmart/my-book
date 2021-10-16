using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
           var newAuthor = _authorsService.AddAuthor(author);
            if (newAuthor != null)
                return Created(nameof(AddAuthor), newAuthor);
            else
                return Ok("Not Created");
        }

        [HttpGet("get-author-books-by-id/{id}")]
        public IActionResult GetAuthorBooksById(int id)
        {
           var author = _authorsService.GetAuthorBooks(id);
            if (author != null)
                return Ok(author);
            else
                return NotFound();
        }

    }
}
