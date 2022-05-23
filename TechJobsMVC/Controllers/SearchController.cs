﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        //(parameter1 is typeOfSearch, parameter2 is searchTerm)
        public IActionResult Results(string searchType, string searchTerm)
        {
            //if (searchBoxValue == null orPerhaps false "" etc)
            //    {
            //     // call FindAll() from JObData etc
            //    }

            //does something else belong here/ i think yes
            //this does the work of putting together the search results
            //pretty sure i need to call this method
            FindByColumnAndValue(searchType, searchTerm);
            return View();
            //should this method instead return a Redirect?
            // return Redirect("Path/To/CorrectPage");
        }
    }
}
