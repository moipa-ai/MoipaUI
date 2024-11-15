using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MoipaUI.Views;

namespace MoipaUI.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty] private string? _userName;

    [ObservableProperty] private bool _loginStatus;

    [ObservableProperty] private string? _passWord;

    [RelayCommand]
    private async Task Login()
    {
        // if (UserName is null || PassWord is null)
        // {
        //     await Shell.Current.DisplayAlert("错误信息", "账号或者密码不能为空！", "OK");
        // }
        // else if (UserName == "admin" && PassWord =="admin")//todo 验证登录逻辑
        // {
        //     await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        // }
        // else
        // {
        //     await Shell.Current.DisplayAlert("错误信息", "账号或者密码错误！", "OK");
        //     UserName = null;
        //     PassWord = null;
        //
        // }
        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");

    }
}