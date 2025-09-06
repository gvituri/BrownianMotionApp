using BrownianMotionApp.Models;
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
        private readonly Random _random = new();

        private readonly Color[] _lineColors = new Color[] {
            Colors.MediumPurple,
            Colors.Orange,
            Colors.Green,
            Colors.Red,
            Colors.Blue,
            Colors.Yellow,
            Colors.Pink,
            Colors.Cyan,
            Colors.Magenta,
            Colors.Lime
        };

        public BrownianMotionChartViewModel(IBrownianMotionService brownianMotionService) {
            _brownianMotionService = brownianMotionService;
        }

        public async Task InitializeAsync() {
            Generate();
        }

        [ObservableProperty]
        double initialPrice = 200;

        [ObservableProperty]
        double volatility = 1;

        [ObservableProperty]
        double meanReturn = 0.1;

        [ObservableProperty]
        int numDays = 200;

        [ObservableProperty]
        int numSimulations = 5;

        [ObservableProperty]
        List<LineDataDTO> lines = new();

        [RelayCommand]
        void Generate() {

            List<LineDataDTO> newLines = new();
            for (int i = 0; i < NumSimulations; i++) {
                var prices = _brownianMotionService.GenerateBrownianMotion(
                    Volatility / 100.0,
                    MeanReturn / 100.0,
                    InitialPrice,
                    NumDays
                );

                var color = _lineColors[i % _lineColors.Length];

                var name = $"Simulação {i+1}";

                var lineData = new LineDataDTO(prices, color, name);
                newLines.Add(lineData);
            }

            Lines = newLines;
        }

        [RelayCommand]
        void Randomize() {
            InitialPrice = Math.Round(_random.NextDouble() * (1000 - 10) + 10, 2);
            Volatility = Math.Round(_random.NextDouble() * 100, 2);
            MeanReturn = Math.Round((_random.NextDouble() * 20) - 10, 2);
            NumDays = _random.Next(30, 365);
        }

        [RelayCommand]
        void StepUpSimulationCount() {
            NumSimulations++;
        }

        [RelayCommand]
        void StepDownSimulationCount() {
            NumSimulations--;
        }
    }
}
