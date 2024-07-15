using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MahApps.Metro.IconPacks;

namespace Password.Controls.Folder;

public partial class Folder
{
    private Expander.Expander.SelectFolder _selectFolder;
    
    private string _folderColor;
    private string _folderName;

    public Folder(PackIconMaterialKind icon, string folderColor, string folderName, int folderNum, Expander.Expander.SelectFolder selectFolder)
    {
        InitializeComponent();
        SizeChanged += Bord_SizeChanged;
        
        _selectFolder = selectFolder;
        _folderColor = folderColor;
        _folderName = folderName;
        
        Ellipse.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(folderColor));
        Icon.Kind = icon;
        FolderName.Text = folderName;
        FolderNum.Text = folderNum.ToString();
    }

    public new string Name
    {
        get
        {
            return _folderName;
        }
    }

    private void Bord_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var folderHeight = 0.6 * ActualWidth - 1;
        Height = folderHeight < 0? 0: folderHeight;
        
        Ellipse.Width = 0.257 * ActualWidth + 0.31;
        Ellipse.Height = Ellipse.Width;
    }

    public void FolderClick()
    {
        ColorAnimation colorAnimation = new ColorAnimation
        {
            From = (Color)ColorConverter.ConvertFromString("#C9CAD3"),
            To = (Color)ColorConverter.ConvertFromString(_folderColor),
            Duration = new Duration(TimeSpan.FromSeconds(0.3))
        };
        Fold.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
        
        Ellipse.Background = Brushes.White;
        Icon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_folderColor));

        FolderName.Foreground = Brushes.White;
        FolderNum.Foreground = Brushes.White;
    }

    public void FolderClear()
    {
        Ellipse.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_folderColor));
        Fold.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C9CAD3"));
        Icon.Foreground = Brushes.White;

        FolderName.Foreground = Brushes.Gray;
        FolderNum.Foreground = Brushes.Gray;
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        FolderClick();
        _selectFolder(this);
    }
}