using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GenericAttributesExample2
{
    class ValidationAttributeExample
    {
        public ValidationAttributeExample()
        {
            var validationResults = new List<ValidationResult>();

            var moon = new Moon
            {
                Name = "Europa",
                DiscoveredBy = "Galileo Galilei, two-time winner of catchiest name ever",
                DiscoveryYear = 2500,  // 1610,
                AverageOrbitDistance = 417002,
                OrbitEccentricity = -0.222,  // it's actually 0.0094 but validators gotta validate
                // Data from https://solarsystem.nasa.gov/moons/jupiter-moons/europa/by-the-numbers/
            };

            Validator.TryValidateObject(moon, new ValidationContext(moon), validationResults, true);

            Console.WriteLine($"Results of {nameof(ValidationAttributeExample)}:\r\n");

            foreach (var vr in validationResults)
                Console.WriteLine(vr.ErrorMessage);
        }
    }

    class StringValidation : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; } = int.MaxValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var str = Convert.ToString(value);

            return str.Length >= MinLength && str.Length <= MaxLength ? ValidationResult.Success : new ValidationResult(null);
        }
    }

    class IntegerValidation : ValidationAttribute
    {
        public int MinValue { get; set; } = int.MinValue;
        public int MaxValue { get; set; } = int.MaxValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var num = Convert.ToInt32(value);

            return num >= MinValue && num <= MaxValue ? ValidationResult.Success : new ValidationResult(null);
        }
    }
    class DoubleValidation : ValidationAttribute
    {
        public double MinValue { get; set; } = double.MinValue;
        public double MaxValue { get; set; } = double.MaxValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var num = Convert.ToDouble(value);
          
            return num >= MinValue && num <= MaxValue ? ValidationResult.Success : new ValidationResult(null);
        }
    }

    class Moon
    {
        [StringValidation(MinLength = 1, MaxLength = 20)]
        public string Name { get; set; }
        
        [AllowNull]
        [StringValidation(MaxLength = 40)]
        public string DiscoveredBy { get; set; }

        [IntegerValidation(MaxValue = 2023)]
        public int DiscoveryYear { get; set; }

        [IntegerValidation(MinValue = 0)]
        public int AverageOrbitDistance { get; set; }

        [DoubleValidation(MinValue = 0)]
        public double OrbitEccentricity { get; set; }
    }
}
