using Newtonsoft.Json;

namespace BitFit.Models
{
    public class IFood
    {
        [JsonProperty("items")]
        public List<Food> AllFoods = new List<Food>();
    }
}
