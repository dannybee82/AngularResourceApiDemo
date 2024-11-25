using ExampleBooksService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBooksApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var items = await _authorService.GetAllAuthors().ConfigureAwait(false);
                return Ok(items);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

    }

}