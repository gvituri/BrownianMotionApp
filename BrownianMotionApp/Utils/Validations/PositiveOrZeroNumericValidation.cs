using InputKit.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Utils.Validations {
    public class PositiveOrZeroNumericValidation : IValidation {
        public string Message { get; set; } = "Este campo só pode conter valores positivos ou zero";

        public bool Validate(object value) {
            if (value is string text && !string.IsNullOrWhiteSpace(text)) {
                if (double.TryParse(text, out double doubleValue)) {
                    return doubleValue >= 0;
                }

                if (int.TryParse(text, out int intValue)) {
                    return intValue >= 0;
                }

            }

            return false;
        }
    }
}
