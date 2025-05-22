using CommunityToolkit.Mvvm.ComponentModel;

namespace GpsBotApp.ViewModels;

public partial class VideoViewModel : ObservableObject
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
