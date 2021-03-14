using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        [HttpPost]
        public ActionResult SimplePost(int? id)
        {
            string jsonString;

            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                jsonString = reader.ReadToEnd();
            }
            var deserialize = JsonSerializer.Deserialize<Values>(jsonString);
            // Вот тут необходима процедура десериализации, обратная JSON.stringify
            return Json(deserialize.Value1+ deserialize.Value2);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
