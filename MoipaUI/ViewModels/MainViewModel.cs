using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MoipaUI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string _name = "不要点";

    [ObservableProperty] private string _text = "my name is moipa";

    [RelayCommand]
    public void GetName()
    {
        Name = "good lucky monkey";
    }

    [RelayCommand]
    private void Add()
    {
        Text = "love word!";
    }

    [RelayCommand]
    private async Task GoToStudent()
    {
        await Shell.Current.GoToAsync("student");
    }
}