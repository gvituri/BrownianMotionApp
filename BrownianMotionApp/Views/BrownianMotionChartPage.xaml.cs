using BrownianMotionApp.ViewModels;

namespace BrownianMotionApp.Views;

public partial class BrownianMotionChartPage : ContentPage {
    public BrownianMotionChartPage(BrownianMotionChartViewModel viewModel) {
        InitializeComponent();
        BindingContext = viewModel;
    }
}