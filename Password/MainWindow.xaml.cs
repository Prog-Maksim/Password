using System.Windows;
using System.Windows.Input;

namespace Password;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}