using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Layout;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Animation;
using Avalonia.Animation.Animators;
using Avalonia.Styling;
using System;
using Avalonia.VisualTree;
using System.Threading;

namespace GpsBotApp.Views;

public partial class ChatView : UserControl
{
    public ChatView()
    {
        InitializeComponent();
    }

    private void OnSendClicked(object? sender, RoutedEventArgs e)
{
    var input = InputBox.Text?.Trim();
    if (string.IsNullOrWhiteSpace(input))
        return;

    // Dymek użytkownika
    var userMessage = CreateMessageBubble($"Ty: {input}", isBot: false);
    ChatHistory.Children.Add(userMessage);
    AnimateMessage(userMessage);

    // Przykładowa odpowiedź bota
    var response = "Kowalski: Raport przyjęty.";
    var botMessage = CreateMessageBubble(response, isBot: true);
    ChatHistory.Children.Add(botMessage);
    AnimateMessage(botMessage);

    InputBox.Text = string.Empty;
}


    
    private Control CreateMessageBubble(string message, bool isBot)
{
    var background = isBot
        ? new SolidColorBrush(Color.Parse("#FFFFFF"))  // jasnoszary dymek bota
        : new SolidColorBrush(Color.Parse("#FFFFFF")); // jasnoniebieski dymek użytkownika

    var cornerRadius = isBot
        ? new CornerRadius(0, 10, 10, 10)
        : new CornerRadius(10, 0, 10, 10);

    var alignment = isBot ? HorizontalAlignment.Left : HorizontalAlignment.Right;

    var bubble = new Border
    {
        Background = background,
        CornerRadius = cornerRadius,
        Padding = new Thickness(10),
        Margin = new Thickness(5),
        HorizontalAlignment = alignment,
        Child = new TextBlock
        {
            Text = message,
            Foreground = Brushes.Black,
            TextWrapping = TextWrapping.Wrap,
            MaxWidth = 300
        }
    };

    // jeśli to użytkownik — zwróć sam dymek
    if (!isBot)
    {
        return new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new Thickness(5),
            Children = { bubble }
        };
    }

    // jeśli to bot — dodaj avatar + dymek
    var avatar = new Border
    {
        Width = 40,
        Height = 40,
        CornerRadius = new CornerRadius(20),
        BorderBrush = Brushes.White,
        BorderThickness = new Thickness(2),
        Child = new Image
        {
            Source = File.Exists("Assets/Kowalski.jpg")
                ? new Avalonia.Media.Imaging.Bitmap("Assets/Kowalski.jpg")
                : null,
            Stretch = Avalonia.Media.Stretch.UniformToFill,
            Clip = new EllipseGeometry
            {
                Center = new Avalonia.Point(20, 20),
                RadiusX = 20,
                RadiusY = 20
            }
        }
    };

    return new StackPanel
    {
        Orientation = Orientation.Horizontal,
        Margin = new Thickness(5),
        Spacing = 5,
        Children =
        {
            avatar,
            bubble
        }
    };
}
private async void AnimateMessage(Control message)
{
    var animation = new Animation
    {
        Duration = TimeSpan.FromMilliseconds(300),
        Children =
        {
            new KeyFrame
            {
                Cue = new Cue(0d),
                Setters =
                {
                    new Setter(Visual.OpacityProperty, 0.0),
                    new Setter(TranslateTransform.XProperty, 20.0),
                }
            },
            new KeyFrame
            {
                Cue = new Cue(1d),
                Setters =
                {
                    new Setter(Visual.OpacityProperty, 1.0),
                    new Setter(TranslateTransform.XProperty, 0.0),
                }
            }
        }
    };

    message.RenderTransform = new TranslateTransform();
    await animation.RunAsync(message, CancellationToken.None);
}

}

