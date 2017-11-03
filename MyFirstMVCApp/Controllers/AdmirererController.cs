using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVCApp.Models;
using MyFirstMVCApp.ViewModels;

namespace MyFirstMVCApp.Controllers
{
    public class AdmirererController : Controller
    {
        //create some admirerers from the Admirerer model, keep it private so only these two local public acctions can utilize this 
        //hardcoded for now, eventually I will use db data
        private readonly List<Admirerer> admirerers = new List<Admirerer>
            {
                new Admirerer { Name = "Nathan Bachmann", Id = 1 },
                new Admirerer { Name = "Jack Travis", Id = 2 },
                new Admirerer { Name = "Ricardo Lee", Id = 3 },
                new Admirerer { Name = "Sam Zwick", Id = 4 },
                new Admirerer { Name = "Jack Brody", Id = 5 },
                new Admirerer { Name = "Ryan Klecka", Id = 6 }
            };


        // GET: Admirerer
        public ActionResult Index()
        {

            //create a viewmodel and include the models we want to comprise it
            var viewModel = new AdmirererViewModel
            {
                Admirerer = admirerers
            };
            
            return View(viewModel);
        }

        // GET: Admirerer/Details
        //pass in the id of the target clicked in the 'Index' view ex: user clicd on Jack Travis, '2' is passed in
        public ActionResult Details(int id)
        {
            //sets to the first element conditionally found otherwise sets the defualt, '0' in this case
            //matches the passed in id with the admirerers object defined above
            var admirerer = admirerers.FirstOrDefault(c => c.Id == id);
            
            //if there are no admirerers
            if (admirerer == null)
                return HttpNotFound();

            //return details view with that admirerer binded
            return View(admirerer);
        }
    }
}