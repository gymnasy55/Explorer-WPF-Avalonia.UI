using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Explorer.Shared.ViewModels;

namespace Explorer.Avalonia.UI.Views
{
    public class MainWindow : Window
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _mainVm = new MainViewModel();
            DataContext = _mainVm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifeTime)
            {
                desktopLifeTime.Shutdown();
            }
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                ((Button)sender).Content = "P";
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                ((Button)sender).Content = "P";
            }
        }

        private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
