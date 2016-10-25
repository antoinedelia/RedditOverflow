using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RedditOverflow.Models
{
    public class Post
    {
        // Title of the Reddit post
        public string Title { get; set; }
        // Self-text
        public string Content { get; set; }
        // Author
        public string Author { get; set; }
        // Subreddit
        public string Subreddit { get; set; }
        // Date of publication
        public DateTime Date { get; set; }
        // Url of the Reddit post
        public string Url { get; set; }
        // If the submission is a link
        public string Link { get; set; }
        // Karma
        public int Score { get; set; }
        // Thumbnail
        public string Thumbnail { get; set; }
        // Number of comments
        public int NumberComments { get; set; }
        // Can't access the comments while we're not on the specific post
        // We know the number of comments
        public List<Comment> ListComments { get; set; }

        public Post()
        {

        }

        public Post(string id)
        {
            if(id != null && id != "") GetInfosFromPost(id);
        }

        private void GetInfosFromPost(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.reddit.com/" + id + ".json");
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
                    var postInfo = JArray.Parse(dataObjects);
                    Title = postInfo[0]["data"]["children"][0]["data"]["title"].ToString();
                    Content = postInfo[0]["data"]["children"][0]["data"]["selftext"].ToString();
                    Author = postInfo[0]["data"]["children"][0]["data"]["author"].ToString();
                    Subreddit = postInfo[0]["data"]["children"][0]["data"]["subreddit"].ToString();
                    DateTime dtpDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dtpDateTime = dtpDateTime.AddSeconds((int)postInfo[0]["data"]["children"][0]["data"]["created_utc"]).ToLocalTime();
                    Date = dtpDateTime;
                    Url = postInfo[0]["data"]["children"][0]["data"]["permalink"].ToString();
                    Link = postInfo[0]["data"]["children"][0]["data"]["url"].ToString();
                    Score = Int32.Parse(postInfo[0]["data"]["children"][0]["data"]["score"].ToString());
                    Thumbnail = postInfo[0]["data"]["children"][0]["data"]["thumbnail"].ToString();
                    NumberComments = Int32.Parse(postInfo[0]["data"]["children"][0]["data"]["num_comments"].ToString());

                    var numberFirstComments = Int32.Parse(postInfo[1]["data"]["children"].ToList().Count.ToString());
                    ListComments = new List<Comment>();
                    for (int i = 0; i < numberFirstComments-1; i++)
                    {
                        Comment comment = new Comment();
                        comment.Author = (string)postInfo[1]["data"]["children"][i]["data"]["author"];
                        comment.Content = (string)postInfo[1]["data"]["children"][i]["data"]["body"];
                        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds((int)postInfo[1]["data"]["children"][i]["data"]["created_utc"]).ToLocalTime();
                        comment.Date = dtDateTime;
                        comment.Score = (int)postInfo[1]["data"]["children"][i]["data"]["score"];

                        ListComments.Add(comment);
                    }
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