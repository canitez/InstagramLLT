using instagram_authorization.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
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

        public async Task<string> TokenParser(string access_key)
        {
            try
            {
                var _InstagramLongModel = new InstagramLongModel();

                if (access_key.HasValue())
                {
                    //shortlive token
                    string ShortTokentUrl = _configuration["InstagramShortTokenUrl"];
                    string Client_Id = _configuration["client_id"];
                    string Client_Secret = _configuration["client_secret"];
                    string Redirect_Uri = _configuration["redirect_uri"];

                    var clientShort = new RestClient(ShortTokentUrl)
                    {
                        Timeout = -1
                    };
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    request.AddParameter("client_id", Client_Id);
                    request.AddParameter("client_secret", Client_Secret);
                    request.AddParameter("grant_type", "authorization_code");
                    request.AddParameter("redirect_uri", Redirect_Uri);
                    request.AddParameter("code", access_key);
                    IRestResponse response = await clientShort.ExecuteAsync(request);

                    if (response.StatusCode.ToString() == "OK")
                    {
                        //short to long
                        var result = JsonConvert.DeserializeObject<InstagramShortModel>(response.Content);
                        string LongTokentUrl = _configuration["InstagramLongTokenUrl"];
                        LongTokentUrl = LongTokentUrl + result.access_token;
                        var clientLong = new RestClient(LongTokentUrl)
                        {
                            Timeout = -1
                        };
                        var requestLong = new RestRequest(Method.GET);
                        IRestResponse responseLong = clientLong.Execute(requestLong);
                        Console.WriteLine(responseLong.Content);

                        _InstagramLongModel = JsonConvert.DeserializeObject<InstagramLongModel>(responseLong.Content);
                    }
                }
                return _InstagramLongModel.access_token;
            }
            catch (Exception)
            {
                return "Token Parser Error";
            }
        }
    }
}
