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

        public async Task<IActionResult> RecipesAsync()
        {
            var query = "mushroom risotto";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get, 
                RequestUri= new Uri("https://api.calorieninjas.com/v1/recipe?query=mushroom_risotto"),
                Headers =
                {
                    { "X-Api-Key", "rjMn+tsZm073LSFbqMeumg==ItLY0mBRQJjLEYno" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var deSerialized = JsonConvert.DeserializeObject<IRecipe>(responseBody);
            return View(deSerialized.AllRecipes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}