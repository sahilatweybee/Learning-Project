using Microsoft.AspNetCore.Mvc;

namespace Learning_Project.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        => _logger = logger;

        [HttpGet]
        public async Task<List<object>> Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("/{id}")]
        public async Task Get([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost()]
        public async Task Post(object model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/{id}")]
        public async Task Put([FromRoute] int id, object model)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/{id}")]
        public async Task Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}
