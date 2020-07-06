using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace instagram_authorization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstagramLLTController : ControllerBase//instagram long-lived token
    {
        private readonly IConfiguration _configuration;

        public InstagramLLTController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string InstagramLLT(string shortLivedToken)
        {
            var str= _configuration["InstagramApiKey:Key"];
            return  _configuration["InstagramApiKey:Key"];

        }
    }
}
