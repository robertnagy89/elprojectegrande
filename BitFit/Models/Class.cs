namespace BitFit.Models
{
    public class Recipe
    {
        public List<Food>? Ingredients { get; set; }
        public int OverallCalories { get; set; }
        public int OverallSugar { get; set; }
        public int OverallFats { get; set; }
        public int OverallCarbohydrates { get; set; }
    }
}
