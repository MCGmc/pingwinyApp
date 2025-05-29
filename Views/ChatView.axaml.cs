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
using System.Linq;

namespace GpsBotApp.Views;

public partial class ChatView : UserControl
{
    private Random _random = new Random();

    public ChatView()
    {
        InitializeComponent();
    }

    private void OnSendClicked(object? sender, RoutedEventArgs e)
    {
        var input = InputBox.Text?.Trim();
        if (string.IsNullOrWhiteSpace(input))
            return;

        var userMessage = CreateMessageBubble($"Ty: {input}", isBot: false);
        ChatHistory.Children.Add(userMessage);
        AnimateMessage(userMessage);

        var response = GetBotResponse(input);
        var botMessage = CreateMessageBubble(response, isBot: true);
        ChatHistory.Children.Add(botMessage);
        AnimateMessage(botMessage);

        InputBox.Text = string.Empty;
    }

    private string GetBotResponse(string inputRaw)
    {
        var input = inputRaw.ToLower().Trim().Replace("?", "");

        if (input.Contains("temperature"))
        {
            string[] options = {
                "Kowalski: The temperature is 16 degrees",
                "Kowalski: Currently it's 16°C",
                "Kowalski: We're seeing a consistent 16 degrees"
            };
            return options[_random.Next(options.Length)];
        }
        else if (input.Contains("location"))
        {
            string[] options = {
                "Kowalski: Right now we are in Sonderborg",
                "Kowalski: We are currently located in Sønderborg",
                "Kowalski: GPS shows Sonderborg"
            };
            return options[_random.Next(options.Length)];
        }
        else if (input.Contains("report") || input.Contains("raport"))
        {
            string[] options = {
                "Kowalski: Stable conditions but King Julian is having a party",
                "Kowalski: All systems are stable. King Julian is celebrating.",
                "Kowalski: Everything's under control, King Julian is dancing."
            };
            return options[_random.Next(options.Length)];
        }
        else if (input.Contains("plans") || input.Contains("secret"))
        {
            string[] options = {
                "Kowalski: Classified plans are in 'Coming back to Denmark'",
                "Kowalski: You can find the plans under 'Coming back to Denmark'",
                "Kowalski: Plans are top secret. Check 'Coming back to Denmark'"
            };
            return options[_random.Next(options.Length)];
        }
        else
        {
            return "Kowalski: I didn’t quite get that. Try asking about temperature, location, plans or a report.";
        }
    }

    private Control CreateMessageBubble(string message, bool isBot)
    {
        var background = isBot
            ? new SolidColorBrush(Color.Parse("#FFFFFF"))
            : new SolidColorBrush(Color.Parse("#FFFFFF"));

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
                    ? new Bitmap("Assets/Kowalski.jpg")
                    : null,
                Stretch = Stretch.UniformToFill,
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

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        var mainWindow = this.GetVisualRoot() as MainWindow;
        if (mainWindow != null)
        {
            mainWindow.Content = new HomeView();
        }
    }
}
