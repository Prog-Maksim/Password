using System.Windows;
using System.Windows.Input;

namespace Password.Controls.Expander;

public partial class Popup
{
    private Expander.AddFolder? func;

    public Popup()
    {
        InitializeComponent();

        func = null;
    }

    public Popup(Expander.AddFolder func): this()
    {
        this.func = func;
    }
    
    private void StoragePopupBorder_OnMouseLeave(object sender, MouseEventArgs e)
    {
        ClosePopup();
    }

    public void ClosePopup()
    {
        StoragePopup.IsOpen = false;
    }

    public void IsOpenPopup()
    {
        StoragePopup.IsOpen = true;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (func is not null)
            func();
    }

    ~Popup()
    {
        StoragePopup = null;
    }
}