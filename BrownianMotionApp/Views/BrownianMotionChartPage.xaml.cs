using BrownianMotionApp.Services;
using BrownianMotionApp.Utils.Drawables;
using BrownianMotionApp.ViewModels;

namespace BrownianMotionApp.Views;

public partial class BrownianMotionChartPage : ContentPage {
    private readonly BrownianMotionDrawable _drawable;
    public BrownianMotionChartPage(BrownianMotionChartViewModel viewModel) {
        InitializeComponent();
        BindingContext = viewModel;
        WindowSizingHelper.MaximizeWindow(App.Current!.Windows[0]);
        System.Threading.Tasks.Task.Factory.StartNew(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.InitializeAsync();
            });
        });

        _drawable = new BrownianMotionDrawable();
        brownianMotionChartView.Drawable = _drawable;

        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(viewModel.Prices)) {
                _drawable.Prices = viewModel.Prices;
                brownianMotionChartView.Invalidate();
            }
        };
    }
}