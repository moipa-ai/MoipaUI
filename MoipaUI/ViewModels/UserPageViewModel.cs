using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MoipaUI.ViewModels;

public partial class UserPageViewModel:ObservableObject
{
    //跳转到网页的方法
    [RelayCommand]
    private async Task AboutUser()
    {
        await Launcher.Default.OpenAsync("https://www.baidu.com/");
    }
}