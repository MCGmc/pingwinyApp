using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace GpsBotApp.Views;

public partial class VideoView : UserControl
{
    public VideoView()
    {
        InitializeComponent();
    }
    private void OnBackClick(object? sender, RoutedEventArgs e)
        {
            var mainWindow = this.GetVisualRoot() as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Content = new HomeView();
            }
        }

}
