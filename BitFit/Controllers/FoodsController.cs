using BitFit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BitFit.Controllers
{
    public class FoodsController : Controller
    {
        
        private readonly ILogger<FoodsController> _logger;

        public FoodsController(ILogger<FoodsController> logger)
        {
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> IndexAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.calorieninjas.com/v1/nutrition?query=banana"),
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
                var i = deSerialized.AllFoods;
                return View(deSerialized.AllFoods);
            }
            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
