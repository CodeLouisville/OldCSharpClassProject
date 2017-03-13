using Microsoft.AspNet.Identity;
using MVCWithUsersAndStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithUsersAndStuff.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            Guid userId;
            if (!Guid.TryParse(User.Identity.GetUserId(),out userId))
            {
                throw new NotSupportedException("You are logged in funny -- ???");
            }

            using (var context = new MovieContext())
            {
                var movies = context.Movies.Where(m => m.UserId == userId).ToList();
                return View("Xanadu", movies);
            }
        }
    }
}