using System;
using System.Collections.Generic;
using System.Linq;
using MappingTool.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace MappingTool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<UserInputViewModel> elementsToBeMatched, List<UserInputViewModel> elementsToBeMatchedAgainst)
        {
            AllElementsViewModel allElements = new AllElementsViewModel(elementsToBeMatched, elementsToBeMatchedAgainst);
            List<List<UserInputViewModel>> elementsToBeMatchedAgainstOrdered = new List<List<UserInputViewModel>>();

            foreach (var item in allElements.ElementsToBeMatched)
            {
                List<UserInputViewModel> currentList = new List<UserInputViewModel>();

                foreach (var element in allElements.ElementsToBeMatchedAgainst)
                {
                    if (LevenshteinDistanceCalculation.LevenshteinDistance(item.Name, element.Name) <= 2)
                    {
                        currentList.Add(element);
                        element.isMapped = true;
                    }
                }
                elementsToBeMatchedAgainstOrdered.Add(currentList);
            }

            foreach (var item in elementsToBeMatchedAgainst)
            {
                if (item.isMapped == false) allElements.UnmappedElements.Add(item);
            }

            allElements.ElementsToBeMatchedAgainstOrdered = elementsToBeMatchedAgainstOrdered;
            this.TempData["serializedObject"] = JsonConvert.SerializeObject(allElements);

            return RedirectToAction("Map", "Home");
        }
        public IActionResult Map()
        {
            var allElements = JsonConvert.DeserializeObject<AllElementsViewModel>(this.TempData["serializedObject"].ToString());

            return View(allElements);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
