using BitFit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;


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
        public async Task<IActionResult> IndexAsync(string searchText=null)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.calorieninjas.com/v1/nutrition?query={searchText}"),
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
                if(deSerialized != null)
                {
                    
                    return View(deSerialized.AllFoods);
                }
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult NewSearch(IFormCollection collection)
        {
            TempData["newSearch"] = collection["SearchBar"];
            if (TempData != null)
            {
                var text = TempData["newSearch"].ToString();
                return RedirectToAction("Index",new {searchText= text });
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
