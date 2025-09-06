using BrownianMotionApp.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.ViewModels {
    public partial class BrownianMotionChartViewModel : ObservableObject {
        private readonly IBrownianMotionService _brownianMotionService;

        public BrownianMotionChartViewModel(IBrownianMotionService brownianMotionService) {
            _brownianMotionService = brownianMotionService;
        }

        public async Task InitializeAsync() {
        }

        [ObservableProperty]
        double initialPrice = 100;

        [ObservableProperty]
        double volatility = 20;

        [ObservableProperty]
        double meanReturn = 1;

        [ObservableProperty]
        int numDays = 252;

        [ObservableProperty]
        double[]? prices;

        [RelayCommand]
        void Generate() {
            Prices = _brownianMotionService.GenerateBrownianMotion(
                Volatility/100,
                MeanReturn/100,
                InitialPrice,
                NumDays
            );
        }
    }
}
