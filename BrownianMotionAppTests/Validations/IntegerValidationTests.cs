using BrownianMotionApp.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Validations {
    public class IntegerValidationTests {

        private readonly IntegerValidation _validator;

        public IntegerValidationTests() {
            _validator = new IntegerValidation();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("123")]
        [InlineData("-42")]
        [InlineData("  999 ")]
        public void Validate_ValidIntegers_ReturnsTrue(string input) {
            bool result = _validator.Validate(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("3.14")]
        [InlineData("-2,71")]
        [InlineData("abc")]
        [InlineData("12a34")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void Validate_InvalidIntegers_ReturnsFalse(string input) {
            bool result = _validator.Validate(input);
            Assert.False(result);
        }
    }
}
