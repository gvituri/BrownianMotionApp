using BrownianMotionApp.Models;
using BrownianMotionApp.Services;
using BrownianMotionApp.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.ViewModels {
    public partial class BrownianMotionChartViewModel : ObservableObject {
        private readonly IBrownianMotionService _brownianMotionService;
        private readonly Random _random = new();

        private Color[] _lineColors = ColorPalettesHelper.GetPalette(ColorPalette.Material);

        public BrownianMotionChartViewModel(IBrownianMotionService brownianMotionService) {
            _brownianMotionService = brownianMotionService;
        }

        public void InitializeAsync() {
            Generate();
        }

        [ObservableProperty]
        private ObservableCollection<string> paletteTypes =
            new ObservableCollection<string>(
                Enum.GetNames(typeof(ColorPalette)).ToList()
            );

        [ObservableProperty]
        string selectedPalette = "Material";

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
        List<LineData> lines = new();

        [RelayCommand]
        void SelectedPaletteChanged(string selectedPalette) {
            if (string.IsNullOrEmpty(selectedPalette)
                || selectedPalette == SelectedPalette) return;

            _lineColors = ColorPalettesHelper.GetPalette(Enum.Parse<ColorPalette>(selectedPalette));

            if (Lines == null || !Lines.Any())
                return;

            for (int i = 0; i < Lines.Count; i++) {
                var color = _lineColors[i % _lineColors.Length];
                Lines[i].Color = color;
            }

            Lines = Lines.ToList();
        }

        [RelayCommand]
        void Generate() {

            List<LineData> newLines = new();
            for (int i = 0; i < NumSimulations; i++) {
                var prices = _brownianMotionService.GenerateBrownianMotion(
                    Volatility / 100.0,
                    MeanReturn / 100.0,
                    InitialPrice,
                    NumDays
                );

                var color = _lineColors[i % _lineColors.Length];

                var lineData = new LineData(prices, color);
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
            Generate();
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
