using Microsoft.AspNetCore.Mvc;
using RadioDemo.Models;
using System.Diagnostics;

namespace RadioDemo.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

    }
}
