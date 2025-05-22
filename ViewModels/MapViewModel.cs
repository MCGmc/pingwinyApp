using CommunityToolkit.Mvvm.ComponentModel;

namespace GpsBotApp.ViewModels;

public partial class MapViewModel : ObservableObject
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
