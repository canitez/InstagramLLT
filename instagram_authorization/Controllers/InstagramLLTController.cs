using instagram_authorization.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace instagram_authorization.Controllers
{
    [ApiAuthorization]
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
            // TODO
            return _configuration["InstagramApiKey:Key"];
        }
    }
}
