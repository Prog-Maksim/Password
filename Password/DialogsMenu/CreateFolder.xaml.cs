using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace Password.DialogsMenu;

public partial class CreateFolder
{
    private readonly List<PackIconMaterialKind> _icons = new()
    {
        PackIconMaterialKind.Delete,
        PackIconMaterialKind.KeyVariant,
        PackIconMaterialKind.AccountMultiple,
        PackIconMaterialKind.Help,
        PackIconMaterialKind.CardsHeart,
        PackIconMaterialKind.CarSide,
        PackIconMaterialKind.Web,
        PackIconMaterialKind.CodeBraces,
        PackIconMaterialKind.Account,
        PackIconMaterialKind.Airplane,
        PackIconMaterialKind.Alarm,
        PackIconMaterialKind.Application,
        PackIconMaterialKind.ArmFlex,
        PackIconMaterialKind.Atom,
        PackIconMaterialKind.Bank,
        PackIconMaterialKind.Book
    };

    public CreateFolder()
    {
        InitializeComponent();
        IconMaterial.Kind = GetRandomIcon();
    }

    public CreateFolder(PackIconMaterialKind folderIcon, string folderName, string folderColor): this()
    {
        IconMaterial.Kind = folderIcon;
        TextBoxName.Text = folderName;
        TextBoxColor.Text = folderColor;
    }

    private PackIconMaterialKind GetRandomIcon()
    {
        Random rnd = new Random();
        return _icons[rnd.Next(_icons.Count - 1)];
    }

    private void CreateFolder_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void Close_OnClick(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
    }

    private bool _isCreate;
    private void UpdateIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        IconPopup.IsOpen = true;
        
        if (_isCreate) return;

        foreach (var icon in _icons)
        {
            Border border = new Border()
            {
                Width = 30,
                Height = 30,
                CornerRadius = new CornerRadius(4),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F6F6F6")),
                Margin = new Thickness(5, 5, 0, 0),
                Cursor = Cursors.Hand,
            };
            
            
            PackIconMaterial material = new PackIconMaterial()
            {
                Kind = icon,
                Width = 20,
                Height = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            material.MouseDown += IconClick;
            
            border.Child = material;
            IconsPanel.Children.Add(border);
        }

        _isCreate = true;
    }

    private void IconClick(object sender, MouseButtonEventArgs e)
    {
        PackIconMaterial material = (PackIconMaterial)sender;
        IconMaterial.Kind = material.Kind;
    }

    public new string Name
    {
        get
        {
            if (TextBoxName.Text == "")
                return "новая папка";
            return TextBoxName.Text;
        }
    }

    public string Color
    {
        get
        {
            if (TextBoxColor.Text == "")
                return "#027AFD";
            return TextBoxColor.Text;
        }
    }

    public new PackIconMaterialKind Icon
    {
        get
        {
            return IconMaterial.Kind;
        }
    }

    private void Enter_OnClick(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
    }

    private void PopupBorder_OnMouseLeave(object sender, MouseEventArgs e)
    {
        IconPopup.IsOpen = false;
    }
}