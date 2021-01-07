using System.Windows;
using System.Windows.Controls;
using Explorer.Shared.ViewModels;

namespace Explorer.WPF.UI
{ 
    public partial class MainWindow
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();
            _mainVm = new MainViewModel();
            DataContext = _mainVm;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();
            Application.Current.Shutdown();
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => WindowState
            };
        }

        private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
