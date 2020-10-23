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
using VideoGameAPI_Example.Authorization;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers.Api
{
    public class TopGamesController : ApiController
    {
        // POST /Api/TopGames
        [HttpPost]
        public IHttpActionResult GetGames(SelectOptionsViewModel selectedOptions)
        {
            var authorize = new Authorize();
            if (!authorize.isAuthorized)
            {
                return BadRequest("IGDB Authorization required!");
            }

            var client = new RestClient(Properties.Settings.Default.igdbUrl + "games");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Client-ID", Properties.Settings.Default.ClientId);

            // use try here in case something is wrong with the token
            try
            {
                request.AddHeader("Authorization", "Bearer " + authorize.accessToken.Value);
            }
            catch (Exception e)
            {
                return BadRequest("IGDB Authorization required! " + e.Message);
            }

            // build the IGDB query string
            var queryString = "fields id, name, genres, category, platforms, game_engines, summary, total_rating; where total_rating >= 80 ";

            // removed the category where clause
            // category is contextual and does not provide the proper meaning 
            //if (selectedOptions.CategoryId > 0)
            //{
            //    queryString += "& category = " + selectedOptions.CategoryId + " ";
            //}

            if (selectedOptions.PlatformId < 1)
            {
                return BadRequest();
            }
            else
            {
                queryString += "& platforms = (" + selectedOptions.PlatformId + ") ";
            }

            if (selectedOptions.GameEngineId > 0)
            {
                queryString += "& game_engines = (" + selectedOptions.GameEngineId + ") ";
            }

            queryString += "; sort total_rating desc; limit 100;"; // add to limit the results

            request.AddParameter("text/plain", queryString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            // close the authorization context
            authorize.Dispose();

            return Json(jsonResponse);
        }
    }
}
