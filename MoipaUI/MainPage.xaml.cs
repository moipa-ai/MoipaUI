using Microsoft.Maui.Controls;
using MoipaUI.ViewModels;


namespace MoipaUI;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public MainPage()
    {
        InitializeComponent();
    }
    
}