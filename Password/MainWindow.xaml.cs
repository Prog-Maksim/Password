using System.Windows;
using System.Windows.Input;
using Password.Controls.Expander;

namespace Password;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;
    }

    public string Version { get; set; } = GlobalVariables.Version;

    # region systemButton
    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void CloseWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }
    
    private bool _isMaximized;

    private void WindowsMaksimum()
    {
        WindowState = WindowState.Maximized;
        _isMaximized = true;
    }

    private void WindowsBase()
    {
        WindowState = WindowState.Normal;
        _isMaximized = false;
    }

    private void WindowSize_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (_isMaximized) WindowsBase();
        else WindowsMaksimum();
    }

    private void WindowMinimize_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    
    #endregion

    private void AuthorizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"Извините, сейчас в версии {GlobalVariables.Version} Password Cloud не работает!", "password inform",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        Expander expander = new Expander(this);
        MainStackPanel.Children.Add(expander);
    }
}