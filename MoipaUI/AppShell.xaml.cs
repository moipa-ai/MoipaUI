using Microsoft.Maui.Controls;
using MoipaUI.Views;

namespace MoipaUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        
    }

    private void SignOutCommand(object sender, System.EventArgs e)
    {
        
    }
}