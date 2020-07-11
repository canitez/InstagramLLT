using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace instagram_authorization.Parser
{
    public class InstagramTokenParser : IInstagramTokenParser
    {
        private readonly IConfiguration _configuration;

        public InstagramTokenParser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> TokenParser(string access_token)
        {
            try
            {
                string baseUrl = _configuration["InstagramBaseUrl"];

                string fullBaseAdress = baseUrl + access_token;

                var client = new RestClient(fullBaseAdress);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                return response.Content;
            }
            catch (Exception)
            {

                return "Token Parser Error";
            }
        }
    }
}
