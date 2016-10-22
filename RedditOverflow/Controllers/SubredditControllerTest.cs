using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedditOverflow.Models;
using System.Web.Mvc;

namespace RedditOverflow.Controllers
{
    [TestClass]
    public class SubredditControllerTest
    {
        [TestMethod]
        public void TestSubredditViewName()
        {
            var controller = new SubredditController();
            var result = controller.Index("") as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestSubredditName()
        {
            var controller = new SubredditController();
            var result = controller.Index("AskReddit") as ViewResult;
            var subreddit = (Subreddit)result.ViewData.Model;
            Assert.AreEqual("AskReddit", subreddit.Name);
        }

        [TestMethod]
        public void TestSubredditPostCount()
        {
            var controller = new SubredditController();
            var result = controller.Index("AskReddit") as ViewResult;
            var subreddit = (Subreddit)result.ViewData.Model;
            Assert.AreEqual(25, subreddit.ListPosts.Count);
        }

        [TestMethod]
        public void TestSubredditPostName()
        {
            var controller = new SubredditController();
            var result = controller.Index("AskReddit") as ViewResult;
            var subreddit = (Subreddit)result.ViewData.Model;
            Assert.AreEqual("AskReddit", subreddit.ListPosts[0].Subreddit);
        }
    }
}