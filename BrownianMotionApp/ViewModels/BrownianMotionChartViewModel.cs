using BrownianMotionApp.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.ViewModels {
    public class BrownianMotionChartViewModel : ObservableObject {
        private readonly IBrownianMotionService _brownianMotionService;

        public BrownianMotionChartViewModel(IBrownianMotionService brownianMotionService) {
            _brownianMotionService = brownianMotionService;
        }

        public async Task InitializeAsync() {
        }
    }
}
