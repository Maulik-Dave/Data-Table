using Demo_JqueryDatatable.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Demo_JqueryDatatable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetJson()
        {
            try
            {
                string raw = System.IO.File.ReadAllText(_environment.WebRootPath + "\\json.txt");
                //var data = JsonHelper.ToClass<dynamic>(raw);
                var sponsors = JsonConvert.DeserializeObject<List<SponsorInfo>>(raw);
                return Json(new { result = "Success", value = sponsors });
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public static class JsonHelper
        {
            public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
            {
                var response = default(T);

                if (!string.IsNullOrEmpty(data))
                    response = jsonSettings == null
                        ? JsonConvert.DeserializeObject<T>(data)
                        : JsonConvert.DeserializeObject<T>(data, jsonSettings);

                return response;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class SponsorInfo
    {
        public string SponsorID { get; set; }
        public string FirstBAID { get; set; }
        public string SecondBAID { get; set; }
        public string ThirdBAID { get; set; }
    }
}