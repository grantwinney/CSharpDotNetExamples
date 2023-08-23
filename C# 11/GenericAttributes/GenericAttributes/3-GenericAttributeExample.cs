using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace GenericAttributesExample3
{
    class GenericAttributeExample
    {
        public GenericAttributeExample()
        {
            var validationResults = new List<ValidationResult>();

            var moon = new Moon
            {
                Name = "Europa",
                DiscoveredBy = "Galileo Galilei, two-time winner of catchiest name ever",
                DiscoveryYear = 2500,  // 1610
                AverageOrbitDistance = 417002,
                OrbitEccentricity = -0.222,  // it's actually 0.0094 but validators gotta validate
            };

            Validator.TryValidateObject(moon, new ValidationContext(moon), validationResults, true);

            Console.WriteLine($"Results of {nameof(GenericAttributeExample)}:\r\n");

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

    class NumberValidation<T> : ValidationAttribute where T : INumber<T>
    {
        public T MinValue { get; set; } = (T)typeof(T).GetField("MinValue").GetValue(null);
        public T MaxValue { get; set; } = (T)typeof(T).GetField("MaxValue").GetValue(null);

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var num = (T?)value;

            return num != null && num >= MinValue && num <= MaxValue ? ValidationResult.Success : new ValidationResult(null);
        }
    }

    class Moon
    {
        [StringValidation(MinLength = 1, MaxLength = 20)]
        public string Name { get; set; }

        [AllowNull]
        [StringValidation(MaxLength = 40)]
        public string DiscoveredBy { get; set; }

        [NumberValidation<int>(MaxValue = 2023)]
        public int DiscoveryYear { get; set; }

        [NumberValidation<int>(MinValue = 0)]
        public int AverageOrbitDistance { get; set; }

        [NumberValidation<double>(MinValue = 0.0)]
        public double OrbitEccentricity { get; set; }
    }
}
