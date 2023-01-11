using BitFit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BitFit.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RecipeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> RecipesAsync(string searchText = "Chicken")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get, 
                RequestUri= new Uri($"https://api.api-ninjas.com/v1/recipe?query={searchText}"),
                Headers =
                {
                    { "X-Api-Key", "rjMn+tsZm073LSFbqMeumg==tUY5fuxhyNZqNik8" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var deSerialized = JsonConvert.DeserializeObject<List<Recipe>>(responseBody);
            return View(deSerialized);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult NewSearch(IFormCollection collection)
        {
            TempData["newSearch"] = collection["SearchBar"];
            if (TempData != null)
            {
                var text = TempData["newSearch"].ToString();
                return RedirectToAction("Recipes", new { searchText = text });
            }
            return RedirectToAction("Recipes");
        }
    }
}