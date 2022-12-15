using Newtonsoft.Json;

namespace BitFit.Models
{
    public class IFood
    {
        [JsonProperty("foods")]
        public List<Food> AllFoods = new List<Food>();
    }
}
