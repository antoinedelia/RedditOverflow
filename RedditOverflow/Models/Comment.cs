using System;
using System.Collections.Generic;

namespace RedditOverflow.Models
{
    public class Comment
    {
        // Content of the comment
        public string Content { get; set; }
        // Author
        public string Author { get; set; }
        // Date of publication
        public DateTime Date { get; set; }
        // Url to the comment
        public string Url { get; set; }
        // Karma
        public int Score { get; set; }
        // List of child comments
        public List<Comment> ListComments { get; set; }

        public Comment()
        {

        }
    }
}