using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace RedditOverflow.Models
{
    public class Subreddit
    {
        // Name of the subreddit
        public string Name { get; set; }
        // Short description of the subreddit
        public string Description { get; set; }
        // List the 25 first hot posts 
        // Might be able to change number and sort of post
        public List<Post> ListPosts { get; set; }

        public Subreddit()
        {

        }

        public Subreddit(string name)
        {
            // If there is no name, we get the posts from /r/all
            Name = name ?? "all";
            // Call to the API
            GetInfosFromSubreddit(name);
        }

        // Call to the Reddit API
        // Get the data and the list of posts
        // If nothing is found, we assume the subreddit does not exist
        private void GetInfosFromSubreddit(string name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.reddit.com/r/" + name + "/hot.json");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string urlParameters = ""; // In case we want to add parameters

            // List data response.
            try
            {
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Getting the JSON from Reddit
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    // TODO get data
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (AggregateException)
            {
                // This can happen if Reddit is down (again?)
                // throw new AggregateException();
            }
        }
    }
}