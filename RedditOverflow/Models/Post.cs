using System;
using System.Collections.Generic;

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
        // Date of publication
        public DateTime Date { get; set; }
        // Url of the Reddit post
        public string Url { get; set; }
        // If the submission is a link
        public string Link { get; set; }
        // Karma
        public int Score { get; set; }
        // Can't access the comments while we're not on the specific post
        // We know the number of comments
        public List<Comment> ListComments { get; set; }

        public Post()
        {

        }
    }
}