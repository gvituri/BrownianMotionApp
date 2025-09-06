using BrownianMotionApp.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Validations {
    public class NegativeNumericValidationTests {
        private readonly NegativeNumericValidation _validator;

        public NegativeNumericValidationTests() {
            _validator = new NegativeNumericValidation();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("123")]
        [InlineData("-42")]
        [InlineData("3,14")]
        [InlineData("-2,71")]
        [InlineData("  999 ")] 
        [InlineData(" -15.5 ")]
        public void Validate_ValidNumbers_ReturnsTrue(string input) {
            bool result = _validator.Validate(input);
            Assert.True(result);
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
