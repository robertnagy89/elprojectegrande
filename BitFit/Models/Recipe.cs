namespace BitFit.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Food>? Ingredients { get; set; }
        public double OverallCalories { get; set; }        
        public double OverallSugar { get; set; }        
        public double OverallFat { get; set; }   
        public double OverallCarbohydrates { get; set; }

        public Recipe(string name, List<Food>? ingredients, double overallCalories, double overallSugar, double overallFat, double overallCarbohydrates)
        {
            Name = name;
            Ingredients = ingredients;
            OverallCalories = overallCalories;
            OverallSugar = overallSugar;
            OverallFat = overallFat;
            OverallCarbohydrates = overallCarbohydrates;
        }
    }
}
