namespace BitFit.Models
{
    public class User
    {
        public int HeightInCm { get; set; }
        public int WeightInKg { get; set; }
        public int Age { get; set; }
        public int BMI { get; set; }

        public int CalculateBMI()
        {
            return WeightInKg / (HeightInCm * HeightInCm / 10000);
        }
    }
}
