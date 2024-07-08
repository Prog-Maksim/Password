using System.Windows.Controls;

namespace Password.Controls.Folder;

public partial class Folder : UserControl
{
    public Folder()
    {
        InitializeComponent();

        DataContext = this;
    }
}