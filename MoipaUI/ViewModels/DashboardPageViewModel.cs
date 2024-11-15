using CommunityToolkit.Mvvm.ComponentModel;

namespace MoipaUI.ViewModels;

public partial class DashboardPageViewModel:ObservableObject
{
    [ObservableProperty] private string? _title;
    [ObservableProperty] private string? _currentMode="自动";
    [ObservableProperty] private int? _temperature=0;
    [ObservableProperty] private int? _humidity=0;

    [ObservableProperty] private bool _deviceSwitchToggled = false;
    
    //值变化的时候调用方法
    partial void OnDeviceSwitchToggledChanged(bool value)
    {
        if (value)
        {
            Humidity = 100;
            Temperature = 35;
        }
        else
        {
            Humidity = 20;
            Temperature = 79;
        }
    }

    public DashboardPageViewModel()
    {
        Title="Dashboard";
    }
    
}