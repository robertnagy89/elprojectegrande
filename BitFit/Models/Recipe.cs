using System.Text.Json.Serialization;

namespace BitFit.Models
{
    public class Recipe
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("ingredients")]
        public List<Food>? Ingredients { get; set; }
        [JsonPropertyName("servings")]
        public string Servings { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        public Recipe(string title, List<Food>? ingredients, string servings, string instructions)
        {
            Title = title;
            Ingredients = ingredients;
            Servings = servings;
            Instructions = instructions;
        }
    }
}
