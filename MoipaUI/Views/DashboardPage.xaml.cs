using MoipaUI.ViewModels;

namespace MoipaUI.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
}