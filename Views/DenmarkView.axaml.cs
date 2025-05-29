using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
namespace GpsBotApp.Views;

public partial class DenmarkView : UserControl
{
    public DenmarkView()
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
