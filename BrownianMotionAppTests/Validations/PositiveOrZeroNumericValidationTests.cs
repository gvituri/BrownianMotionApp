using BrownianMotionApp.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Validations {
    public class PositiveOrZeroNumericValidationTests {
        private readonly PositiveOrZeroNumericValidation _validator;

        public PositiveOrZeroNumericValidationTests() {
            _validator = new PositiveOrZeroNumericValidation();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("123")]
        [InlineData("3,14")]
        [InlineData("0,0001")]
        [InlineData("  999 ")]
        public void Validate_PositiveOrZeroNumbers_ReturnsTrue(string input) {
            bool result = _validator.Validate(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-42")]
        [InlineData("-3,14")]
        [InlineData("-0,01")]
        public void Validate_NegativeNumbers_ReturnsFalse(string input) {
            bool result = _validator.Validate(input);
            Assert.False(result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("12a34")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void Validate_InvalidInput_ReturnsFalse(string input) {
            bool result = _validator.Validate(input);
            Assert.False(result);
        }
    }
}
