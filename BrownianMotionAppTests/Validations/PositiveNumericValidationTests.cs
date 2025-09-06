using BrownianMotionApp.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Validations {
    public class PositiveNumericValidationTests {
        private readonly PositiveNumericValidation _validator;

        public PositiveNumericValidationTests() {
            _validator = new PositiveNumericValidation();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("123")]
        [InlineData("3,14")]
        [InlineData("0,0001")]
        [InlineData("  999 ")]
        public void Validate_PositiveNumbers_ReturnsTrue(string input) {
            bool result = _validator.Validate(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("-42")]
        [InlineData("-3,14")]
        [InlineData("-0,01")]
        public void Validate_NonPositiveNumbers_ReturnsFalse(string input) {
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
