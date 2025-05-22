using CommunityToolkit.Mvvm.ComponentModel;

namespace GpsBotApp.ViewModels;

public partial class DenmarkViewModel : ObservableObject
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
