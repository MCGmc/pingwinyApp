using Avalonia.Controls;
using CefNet.Avalonia;
using System;
using System.IO;

namespace GpsBotApp.Views;

public partial class MapView : UserControl
{
    public MapView()
    {
        InitializeComponent();

       Content = new TextBlock
    {
        Text = "Tu miała być mapa, ale WebView wyłączony.",
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
    };
    }
}
