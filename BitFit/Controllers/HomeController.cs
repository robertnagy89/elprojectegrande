using BitFit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BitFit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var data = await GetSampleDataAsync();
            if (data == null)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(data.AllFoods);
        }

        private async Task<IFood> GetSampleDataAsync()
        {
            var url = "https://getpantry.cloud/apiv1/pantry/1899cfa8-43b1-4e43-a87a-7e5385f2def1/basket/foods";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var deSerialized = JsonConvert.DeserializeObject<IFood>(responseBody);
            return deSerialized;
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
}