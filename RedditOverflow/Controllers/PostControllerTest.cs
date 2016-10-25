using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedditOverflow.Models;
using System.Web.Mvc;

namespace RedditOverflow.Controllers
{
    [TestClass]
    public class PostControllerTest
    {
        [TestMethod]
        public void TestPostViewName()
        {
            var controller = new PostController();
            var result = controller.Index("") as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestPostName()
        {
            var controller = new PostController();
            var result = controller.Index("/r/StarWars/comments/3qvj6w/theory_jar_jar_binks_was_a_trained_force_user/") as ViewResult;
            var post = (Post)result.ViewData.Model;
            Assert.AreEqual("StarWars", post.Subreddit);
        }
    }
}