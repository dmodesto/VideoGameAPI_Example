using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGameAPI_Example.Authorization;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers.Api
{
    public class GameController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var authorize = new Authorize();
            if (!authorize.isAuthorized)
            {
                return BadRequest("IGDB Authorization required!");
            }

            var queryURL = Properties.Settings.Default.igdbUrl + "games";
            var client = new RestClient(queryURL);
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
            var queryString = "fields id, name, genres, category, platforms, summary, total_rating, cover.*, url; where id = " + Id + ";";

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
                view.CoverId = jsonResponse[0].cover.id;
                view.Url = jsonResponse[0].url;
                view.CoverUrl = jsonResponse[0].cover.url;
            }
            catch (Exception)
            {
                return BadRequest("Requried values missing from IGDB!");
            }

            // close the authorization context
            authorize.Dispose();

            return Ok(view);
        }

    }
}
