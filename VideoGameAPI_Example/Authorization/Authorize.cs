using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using VideoGameAPI_Example.Models;

namespace VideoGameAPI_Example.Authorization
{
    public class Authorize
    {
        public bool isAuthorized = false;
        public AccessToken accessToken;
        private ApplicationDbContext _context;

        public Authorize()
        {
            _context = new ApplicationDbContext();

            // pull the only access token from the db
            accessToken = _context.AccessTokens.FirstOrDefault();

            validateToken();
        }

        public bool validateToken()
        {
            if (accessToken == null)
            {
                Debug.WriteLine("Need a new token.");
                // get a new access token
                getAccessToken();
            }

            if (isAuthorized)
            {
                Debug.WriteLine("The token is authorized.");
                return isAuthorized;
            }

            Debug.WriteLine("The token is not authorized. So validate it.");

            // validate the access token
            var queryURL = Properties.Settings.Default.oauthUrl + "validate";
            var client = new RestClient(queryURL);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "OAuth " + accessToken.Value);
            request.AddHeader("Content-Type", "text/plain");

            // get the validation details
            IRestResponse response = client.Execute(request);

            if(response.IsSuccessful)
            {
                Debug.WriteLine("The token is valid.");
                isAuthorized = true;
                return isAuthorized;
            }
            else
            {
                Debug.WriteLine("The token is not valid.");
                // get a new access token
                getAccessToken();
            }

            return isAuthorized;
        }

        private void getAccessToken()
        {
            // request a new access token
            var queryURL = Properties.Settings.Default.oauthUrl + "token";
            var client = new RestClient(queryURL);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddParameter("client_id", Properties.Settings.Default.ClientId);
            request.AddParameter("client_secret", Properties.Settings.Default.ClientSecret);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);

            // get the authorization details
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            // create a new accessToken if one doesn't exist
            if (accessToken == null)
            {
                accessToken = new AccessToken();
            }

            // set the accessToken to the new token
            try {
                accessToken.Name = "Twitch";
                accessToken.Value = jsonResponse.access_token;
                accessToken.Type = "Bearer";
                accessToken.ExpiresIn = jsonResponse.expires_in;
                isAuthorized = true;
            }
            catch (Exception e) {
                Debug.WriteLine("Error: " + e.Message);
                isAuthorized = false;
            }

            // if new token received then set isAuthorized
            if (isAuthorized) {
                // save the updated accessToken to the database
                var currentAccessToken = _context.AccessTokens.FirstOrDefault();

                if (currentAccessToken == null)
                {
                    _context.AccessTokens.Add(accessToken);
                }
                else
                {
                    currentAccessToken.Value = accessToken.Value;
                    currentAccessToken.ExpiresIn = accessToken.ExpiresIn;
                }

                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}