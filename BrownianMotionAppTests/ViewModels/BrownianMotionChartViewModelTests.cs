using BrownianMotionApp.Models;
using BrownianMotionApp.Services;
using BrownianMotionApp.Services.Interfaces;
using BrownianMotionApp.ViewModels;
using Moq;
using Xunit;
namespace BrownianMotionAppTests.ViewModels {
    public class BrownianMotionChartViewModelTests {
        private readonly Mock<IBrownianMotionService> _mockService;

        public BrownianMotionChartViewModelTests() {
            _mockService = new Mock<IBrownianMotionService>();
            _mockService.Setup(s => s.GenerateBrownianMotion(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>()))
                        .Returns<double, double, double, int>((sigma, mean, init, days) => Enumerable.Repeat(init, days).ToArray());
        }

        [Fact]
        public void InitializeAsync_ShouldPopulateLines() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object);

            vm.InitializeAsync();

            Assert.NotEmpty(vm.Lines);
            Assert.Equal(vm.NumSimulations, vm.Lines.Count);
        }

        [Fact]
        public void Generate_ShouldCallServiceAndSetLines() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object) {
                NumSimulations = 3,
                NumDays = 10
            };

            vm.Generate();

            Assert.Equal(3, vm.Lines.Count);
            Assert.All(vm.Lines, line => Assert.Equal(10, line.Prices.Length));
        }

        [Fact]
        public void SelectedPaletteChanged_ShouldUpdateColors() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object);
            vm.Generate();

            var oldColors = vm.Lines.Select(l => l.Color).ToList();

            vm.SelectedPaletteChanged(ColorPalette.Cyberpunk.ToString());

            var newColors = vm.Lines.Select(l => l.Color).ToList();

            Assert.NotEqual(oldColors, newColors);
        }

        [Fact]
        public void StepUpSimulationCount_ShouldIncreaseNumSimulations() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object) { NumSimulations = 5 };

            vm.StepUpSimulationCount();

            Assert.Equal(6, vm.NumSimulations);
        }

        [Fact]
        public void StepDownSimulationCount_ShouldDecreaseNumSimulations() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object) { NumSimulations = 5 };

            vm.StepDownSimulationCount();

            Assert.Equal(4, vm.NumSimulations);
        }

        [Fact]
        public void Randomize_ShouldChangeValuesAndGenerateLines() {
            var vm = new BrownianMotionChartViewModel(_mockService.Object);

            var oldPrice = vm.InitialPrice;
            vm.Randomize();

            Assert.NotEqual(oldPrice, vm.InitialPrice);
            Assert.NotEmpty(vm.Lines);
        }
    }
}
