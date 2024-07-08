using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace Password;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

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
}