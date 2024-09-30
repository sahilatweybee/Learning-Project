using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Project_Template.API.Controllers
{
    [NonController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
