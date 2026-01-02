using Microsoft.Maui.Controls;

namespace MoipaUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();  
    }
}