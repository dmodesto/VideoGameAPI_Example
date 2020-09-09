using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers.Api
{
    public class GameController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var queryURL = Properties.Settings.Default.igdbUrl + "games";
            var client = new RestClient(queryURL);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("user-key", Properties.Settings.Default.userKey);
            request.AddHeader("Content-Type", "text/plain");

            // build the IGDB query string
            var queryString = "fields id, name, genres, category, platforms, summary, total_rating, cover, url; where id = " + Id + ";";

            request.AddParameter("text/plain", queryString, ParameterType.RequestBody);

            // get the game details
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            var view = new GameViewModel();

            // wrap this section in a try catch block
            // when caught send user back to search with Bad Request parameter
            try
            {
                view.Id = jsonResponse[0].id;
                view.Name = jsonResponse[0].name;
                view.Genres = jsonResponse[0].genres.ToString();
                view.CategoryId = jsonResponse[0].category;
                view.Platforms = jsonResponse[0].platforms.ToString();
                view.Summary = jsonResponse[0].summary;
                view.TotalRating = jsonResponse[0].total_rating;
                view.CoverId = jsonResponse[0].cover;
                view.Url = jsonResponse[0].url;
                view.CoverUrl = "";
            }
            catch (Exception)
            {
                return BadRequest("Requried values missing from IGDB!");
            }

            //get the game cover art
            queryURL = Properties.Settings.Default.igdbUrl + "covers";
            client = new RestClient(queryURL);
            client.Timeout = -1;

            request = new RestRequest(Method.POST);
            request.AddHeader("user-key", Properties.Settings.Default.userKey);
            request.AddHeader("Content-Type", "text/plain");

            // query string to grab the cover image
            queryString = "fields url; where id = " + jsonResponse[0].cover + ";";

            request.AddOrUpdateParameter("text/plain", queryString, ParameterType.RequestBody);

            // get the game details
            response = client.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                jsonResponse = JsonConvert.DeserializeObject(response.Content);
                view.CoverUrl = jsonResponse[0].url;
            }
            
            return Ok(view);
        }

    }
}
