using RedditOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedditOverflow.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(string id)
        {
            Post post = new Post(id);
            return View("Index", post);
        }
    }
}