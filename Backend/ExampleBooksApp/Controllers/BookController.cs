using ExampleBooksService.DataTransferObjects;
using ExampleBooksService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBooksApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var items = await _bookService.GetAllBooks().ConfigureAwait(false);
                return Ok(items);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var item = await _bookService.GetBookById(id).ConfigureAwait(false);
                return Ok(item);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBook([FromBody] BookDto dto)
        {
            try
            {
                await _bookService.CreateBook(dto);
                return Ok();
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto dto)
        {
            try
            {
                await _bookService.UpdateBook(dto);
                return Ok();
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBook(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

    }

}