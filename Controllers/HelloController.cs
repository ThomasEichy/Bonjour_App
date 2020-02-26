using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bonjour_App.Models;

namespace Bonjour_App.Controllers
{
    public class HelloController : Controller
    {
        [Route("/Hello")]
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
            "<input type='text' name='name' />" +
            "<select name='language'>" +
            "   <option value='Hello'>English</option>" +
            "   <option value='Bonjour'>French</option>" +
            "   <option value='Hola'>Spanish</option>" +
            "   <option value='Hallo'>German</option>" +
            "   <option value='Hei'>Finnish</option>" +
            "</select>" +
            "<input type='submit' value='Say Hello!' />";

            return Content(html, "text/html");
        }

        [Route("/Hello")]
        [HttpPost]
        public IActionResult CreateMessage(string name, string language)
        {

            int numVisits = 0;
            var visitors = Request.Cookies["visits"];
            Console.WriteLine(visitors+"\n\n");

            if (visitors == null) {
                visitors = "1";
                numVisits = 1;
                Response.Cookies.Append("visits", visitors);
                Console.WriteLine(Request.Cookies["visits"]+"\n\n True");
            }
            else {
                numVisits = int.Parse(visitors);
                numVisits++;
                Response.Cookies.Append("visits", numVisits.ToString());
                Console.WriteLine(Request.Cookies["visits"]+"\n\n False");
            }

            return Content(string.Format("<h1>{0} {1}</h1> <p>&nbsp;</p> <p>Times used: {2}</p>", 
            language, name, numVisits), "text/html");
        }
    }
}
