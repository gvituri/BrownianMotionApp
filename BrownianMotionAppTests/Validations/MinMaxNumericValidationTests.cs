using BrownianMotionApp.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Validations {
    public class MinMaxNumericValidationTests {
        private readonly MinMaxNumericValidation _validator;

        public MinMaxNumericValidationTests() {
            _validator = new MinMaxNumericValidation {
                MinValue = 10,
                MaxValue = 100
            };
        }

        [Theory]
        [InlineData("10")]   
        [InlineData("100")]  
        [InlineData("50")]   
        [InlineData("10,0")] 
        [InlineData("99,99")]
        public void Validate_ValidNumbers_ReturnsTrue(string input) {
            bool result = _validator.Validate(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("9")]     
        [InlineData("101")]   
        [InlineData("9,99")]  
        [InlineData("100,01")]
        [InlineData("-50")]   
        public void Validate_OutOfRangeNumbers_ReturnsFalse(string input) {
            bool result = _validator.Validate(input);
            Assert.False(result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("50a")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void Validate_InvalidInput_ReturnsFalse(string input) {
            bool result = _validator.Validate(input);
            Assert.False(result);
        }
    }
}
