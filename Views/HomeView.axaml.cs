using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace GpsBotApp.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void OnMapClick(object? sender, RoutedEventArgs e)
        {
            if (GetMainWindow() is { } mainWindow)
                mainWindow.Content = new MapView();
        }

        private void OnVideoClick(object? sender, RoutedEventArgs e)
        {
            if (GetMainWindow() is { } mainWindow)
                mainWindow.Content = new VideoView();
        }

        private void OnChatClick(object? sender, RoutedEventArgs e)
        {
            if (GetMainWindow() is { } mainWindow)
                mainWindow.Content = new ChatView();
        }

        private void OnDenmarkClick(object? sender, RoutedEventArgs e)
        {
            if (GetMainWindow() is { } mainWindow)
                mainWindow.Content = new DenmarkView();
        }

        private MainWindow? GetMainWindow()
        {
            return this.GetVisualRoot() as MainWindow;
        }
    }
}
