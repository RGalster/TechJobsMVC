using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        //this does the work of putting together the search results
        //(parameter1 is typeOfSearch, parameter2 is searchTerm)
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null)
            {
                jobs = JobData.FindAll();
                ViewBag.title = "Displaying all Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //finish the title of the page
                //by making a new string for searchType
                if (searchType == "positionType")
                {
                    searchType = "position type";
                }
                if (searchType == "coreCompetency")
                {
                    searchType = "skill";
                }
                ViewBag.title = "Displaying " + searchType + " results for: " + searchTerm;
            }
            // added one line of code
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobs;

            return View("Index");

            //return index view specifically
            //if (searchBoxValue == null orPerhaps false "" etc)
            //    {
            //     // call FindAll() from JObData etc
            //    }

            //does something else belong here/ i think yes
            
            //i need to call FindByColumnAndValue (what does it return?  a list of Job objects?)
            //i think it returns a view

            //FindByColumnAndValue(searchType, searchTerm);
            //return View();

            //should this method instead return a Redirect?

            // return Redirect("Path/To/CorrectPage");

            //Results() interface should look very similar to my
            //Jobs() interface in ListController
        }
    }
}
