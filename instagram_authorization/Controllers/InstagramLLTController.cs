using instagram_authorization.Filter;
using instagram_authorization.Parser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace instagram_authorization.Controllers
{
    [ApiAuthorization]
    [ApiController]
    [Route("[controller]")]
    public class InstagramLLTController : ControllerBase//instagram long-lived token
    {
        private readonly IInstagramTokenParser _parser;

        //readonly new InstagramTokenParser parser;

        public InstagramLLTController(IInstagramTokenParser parser)
        {
            _parser = parser;
        }

        [HttpPost]
        public async Task<string> InstagramLLT([FromBody]string instagramKey)
        {
            return await _parser.TokenParser(instagramKey);
        }
    }
}
