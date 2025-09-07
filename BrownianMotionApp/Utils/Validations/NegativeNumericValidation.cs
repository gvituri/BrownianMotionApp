using InputKit.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Utils.Validations {

    /// <summary>
    /// Validação que garante que o valor informado seja um número válido, podendo ser positivo ou negativo.
    /// </summary>
    public class NegativeNumericValidation : IValidation {
        public string Message { get; set; } = "O valor deve ser um número positivo ou negativo";

        public bool Validate(object value) {
            if (value is string text && !string.IsNullOrWhiteSpace(text)) {
                text = text.Trim();

                if (double.TryParse(text, out double _)) {
                    return true;
                }

                if (int.TryParse(text, out int _)) {
                    return true;
                }

            }

            return false;
        }
    }
}
