using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trailblazer.Server.Data.Repositories;
using Trailblazer.Server.Models;

namespace Trailblazer.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IDataTrailblazer _dataTrailblazer;

        public TestController(IDataTrailblazer dataTrailblazer)
        {
            _dataTrailblazer = dataTrailblazer;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            try
            {
                //test
                var data = await _dataTrailblazer.Test();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
