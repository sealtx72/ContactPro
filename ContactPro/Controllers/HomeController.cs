using System.Diagnostics;
using ContactPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();
            
            customError.Code = code;

            if (code == 404)
            {
                customError.Message = "The page you are looking for might have been removed, had its name changed or is temporarily unavailable";
            }
            else if (code == 500)
            {
                customError.Message = "Sorry, an unexpected error occurred on the server.";
            }
            else
            {
                customError.Message = "An unexpected error occurred.";
            }

            return View("~/Views/Shared/CustomError.cshtml", customError);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
