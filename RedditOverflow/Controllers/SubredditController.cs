using RedditOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedditOverflow.Controllers
{
    public class SubredditController : Controller
    {
        // GET: Subreddit
        public ActionResult Index(string id)
        {
            // Creating the subreddit based on it's name
            Subreddit subreddit = new Subreddit(id);
            return View(subreddit);
        }
    }
}