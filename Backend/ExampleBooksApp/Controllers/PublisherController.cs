using ExampleBooksService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBooksApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPublishers()
        {
            try
            {
                var items = await _publisherService.GetAllPublishers().ConfigureAwait(false);
                return Ok(items);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

    }

}