using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VideoGameAPI_Example.Controllers.Api
{
    public class TopGamesController : ApiController
    {
        // GET
        [HttpGet]
        public IHttpActionResult Index()
        {
            var client = new RestClient(Properties.Settings.Default.igdbUrl + "games");                        
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("user-key", Properties.Settings.Default.userKey);
            request.AddHeader("Content-Type", "text/plain");

            // Todo: use passed parameters to build the query string
            request.AddParameter("text/plain", "fields *; where platforms = [165] & total_rating >= 75; sort total_rating desc; limit 25;", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            return Json(jsonResponse);
        }
    }
}
