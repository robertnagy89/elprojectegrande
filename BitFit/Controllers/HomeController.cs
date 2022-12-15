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
            return View(data.AllFoods);             
        }

        private async Task<IFood> GetSampleDataAsync()
        {
            string sample = "apple and bread and coffee";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.calorieninjas.com/v1/nutrition?query={sample}"),
                Headers =
            {
                { "X-Api-Key", "Psij6QAOOFNwBBxyV91U4w==n1GEtDahReZRqJfI" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var deSerialized = JsonConvert.DeserializeObject<IFood>(responseBody);
                return deSerialized;
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
}