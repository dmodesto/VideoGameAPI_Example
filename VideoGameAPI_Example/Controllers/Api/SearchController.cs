using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers.Api
{
    public class SearchController : ApiController
    {
        // POST /Api/TopGames
        [HttpPost]
        public IHttpActionResult GetGames(SearchViewModel viewModel)
        {
            var client = new RestClient(Properties.Settings.Default.igdbUrl + "games");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("user-key", Properties.Settings.Default.userKey);
            request.AddHeader("Content-Type", "text/plain");

            // build the IGDB query string
            var queryString = "fields id, name, genres, category, platforms, game_engines, summary, total_rating; " +
                "search \"" + viewModel.Name + "\"; where version_parent = null; limit 100;";

            request.AddParameter("text/plain", queryString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            return Json(jsonResponse);
        }
    }
}
