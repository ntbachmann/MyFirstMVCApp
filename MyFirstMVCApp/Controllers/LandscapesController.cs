using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVCApp.Models;
using MyFirstMVCApp.ViewModels;

namespace MyFirstMVCApp.Controllers
{
    public class LandscapesController : Controller
    {
        //hardcoded artworks that are accessible only to this class
        private readonly List<Landscapes> landscape = new List<Landscapes>
        {
            new Landscapes { Name = "Starry Night" },
            new Landscapes { Name = "Water Lillies" }
        };


        // GET: Landscapes/Random
        //good practice to return a 'ViewResult' when returning a view, instead of an ActionResult (though this covers all other commented out cases)
        public ActionResult Random()
        {
            var viewModel = new RandomLandscapeViewModel
            {
                Landscapes = landscape,
            };
            return View(viewModel);                                                          //put the model in the view so we can render it (one way to pass data to views)
            //return Content("Hello World!");                                                //content is displayed as the view
            //return HttpNotFound();                                                         //yields 404 not found
            //return new EmptyResult();                                                      //yields blank page
            //return RedirectToAction("Index", "Home", new { page =1, sortBy = "name" });    //redirects to the home controller, the index action, arguments that will be passed into the URL
        }
        
        //GET: Landscapes/Random2
        //public ActionResult Random2()
        //{
        //    //create a landscape from the landscapes model
        //    var landscape = new Landscapes() { Name = "Starry Night" };
        //
        //    //create some admirerers from the Admirerer model
        //    var admirerers = new List<Admirerer>
        //    {
        //        new Admirerer { Name = "Nathan Bachmann" },
        //        new Admirerer { Name = "Jack Travis" },
        //        new Admirerer { Name = "Ricardo Lee" },
        //        new Admirerer { Name = "Sam Zwick" },
        //        new Admirerer { Name = "Jack Brody" },
        //        new Admirerer { Name = "Ryan Klecka" }
        //    };
        //
        //    //create a viewmodel and include the models we want to comprise it
        //    var viewModel = new RandomLandscapeViewModel
        //    {
        //        Landscapes = landscape,
        //        Admirerer = admirerers
        //    };
        //
        //    return View(viewModel);
        //}
        //
        
        //---------------------------------------------------- Custom Routing -------------------------------------------------------------------//
        //use attribute routing for any neccessary custom routes
        //to enable this ability, see instantiation in RouteConfig.cs
        [Route("landscapes/complete/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByCompletionYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //example to show how a custom route works the crappy way. see RouteConfig.cs
        public ActionResult ByCompletionDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //-------------------------------------------------- End Custom Routing ------------------------------------------------------------------//


        // GET: Landscapes/Edit/<id> or Landscapes/Edit?id=1
        //if 'id' variable is changed to some other name, you cannot use Landscapes/Edit/1, only id is supported by our route defaults
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // GET: Landscapes
        //can change the content displayed by -> /landscapes?pageIndex=2&sortBy=ReleaseDate
        //will return Landscapes in the database, 
        //if the movie is not specified, takes us to page 1, but it is an optional parameter with the ? after int
        //String is always an optional (nullable) parameter
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //yields "pageIndex=1&sortBy=Name" on the screen when nothing is passed in
            //{0} -> first parameter
            //{1} -> second parameter
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}