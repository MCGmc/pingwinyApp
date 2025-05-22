using CommunityToolkit.Mvvm.ComponentModel;

namespace GpsBotApp.ViewModels;

public partial class ChatViewModel : ObservableObject
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
