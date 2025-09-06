using BrownianMotionApp.Services;
using BrownianMotionApp.ViewModels;

namespace BrownianMotionApp.Views;

public partial class BrownianMotionChartPage : ContentPage {
    public BrownianMotionChartPage(BrownianMotionChartViewModel viewModel) {
        InitializeComponent();
        BindingContext = viewModel;
        WindowSizingHelper.MaximizeWindow(App.Current!.Windows[0]);
        System.Threading.Tasks.Task.Factory.StartNew(() => {
            MainThread.BeginInvokeOnMainThread(async () => {
                await viewModel.InitializeAsync();
            });
        });
    }
}