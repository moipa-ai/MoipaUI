using CommunityToolkit.Mvvm.Input;

namespace MoipaUI.ViewModels;

public partial class StudentViewModel : MainViewModel
{
    // [ObservableProperty]
    // private string? _name;
    //
    [RelayCommand]
    public void GoToLogin()
    {
        Shell.Current.GoToAsync("student");
    }

    [RelayCommand]
    private void GoBack()
    {
        Shell.Current.GoToAsync("..");
    }
}