using InputKit.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Utils.Validations {
    public class MinMaxNumericValidation : IValidation {
        public double MinValue { get; set; } = double.MinValue;
        public double MaxValue { get; set; } = double.MaxValue;
        public string Message => $"O valor deve estar entre {MinValue} e {MaxValue}";

        public bool Validate(object value) {
            if (value is string text && !string.IsNullOrWhiteSpace(text)) {
                double numericValue;

                if (int.TryParse(text, out int intValue)) {
                    numericValue = intValue;
                } else if (double.TryParse(text, out double doubleValue)) {
                    numericValue = doubleValue;
                } else {
                    return false;
                }

                return numericValue >= MinValue && numericValue <= MaxValue;
            }

            return false;
        }
    }
}
