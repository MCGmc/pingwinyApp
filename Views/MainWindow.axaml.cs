using Avalonia.Controls;

namespace GpsBotApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentView.Content = new HomeView();
        }

        private void OnMapClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentView.Content = new MapView();
        }

        private void OnVideoClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentView.Content = new VideoView();
        }

        private void OnChatClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentView.Content = new ChatView();
        }

        private void OnDenmarkClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentView.Content = new DenmarkView();
    
    
        }

        public void NavigateToHome()
{
    ContentView.Content = new HomeView();
}
    }
    
}
