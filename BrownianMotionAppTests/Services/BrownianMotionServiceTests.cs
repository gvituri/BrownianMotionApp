using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionAppTests.Services {
    public class BrownianMotionServiceTests {
        [Fact]
        public void GenerateBrownianMotion_ReturnsCorrectLength() {
            var service = new BrownianMotionService(new Random(42));
            int numDays = 100;
            var result = service.GenerateBrownianMotion(0.2, 0.05, 100.0, numDays);

            Assert.Equal(numDays, result.Length);
        }

        [Fact]
        public void GenerateBrownianMotion_FirstPriceEqualsInitial() {
            var service = new BrownianMotionService(new Random(42));
            var result = service.GenerateBrownianMotion(0.2, 0.05, 100.0, 50);

            Assert.Equal(100.0, result[0]);
        }

        [Fact]
        public void GenerateBrownianMotion_AllPricesPositive() {
            var service = new BrownianMotionService(new Random(42));
            var result = service.GenerateBrownianMotion(0.2, 0.05, 100.0, 50);

            Assert.All(result, price => Assert.True(price > 0));
        }

        [Fact]
        public void GenerateBrownianMotion_ReproducibleWithSeed() {
            var service1 = new BrownianMotionService(new Random(42));
            var service2 = new BrownianMotionService(new Random(42));

            var result1 = service1.GenerateBrownianMotion(0.2, 0.05, 100.0, 10);
            var result2 = service2.GenerateBrownianMotion(0.2, 0.05, 100.0, 10);

            Assert.Equal(result1, result2);
        }
    }
}
