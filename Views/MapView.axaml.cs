using Avalonia.Controls;
using CefNet.Avalonia;
using System;
using System.IO;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;




namespace GpsBotApp.Views;

public partial class MapView : UserControl
{
    public MapView()
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
