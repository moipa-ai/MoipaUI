using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoipaUI.IServers;
using MoipaUI.Models;

namespace MoipaUI.ViewModels;

public partial class DashboardPageViewModel:ObservableObject
{
    [ObservableProperty] private string? _title;
    [ObservableProperty] private string? _currentMode="自动";
    [ObservableProperty] private int? _temperature=0;
    [ObservableProperty] private int? _humidity=0;
    [ObservableProperty] private bool _deviceSwitchToggled = false;
    
    private readonly IMqttServer _mqttServer ;
    
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

    public DashboardPageViewModel(IMqttServer mqttServer)
    {
        _mqttServer = mqttServer;
        Title="Dashboard";
    }

    [RelayCommand]
    private void PublishMessage(string message)
    {
        _mqttServer.PublishMessage(message);
    }
}