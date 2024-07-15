using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MahApps.Metro.IconPacks;

namespace Password.Controls.Expander;

public partial class Expander
{
    private List<Grid> _grids;
    
    public delegate void AddFolder();
    public delegate void SelectFolder(Folder.Folder folder);

    private Folder.Folder? _active;
    
    public Expander()
    {
        InitializeComponent();

        _grids = new List<Grid>();
    }

    private Popup? _PopupIsCreate;
    
    private void ExpanderText_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_PopupIsCreate is null)
        {
            AddFolder func = AddNewFolder;
        
            Popup pop = new Popup(func);
            pop.IsOpenPopup();

            _PopupIsCreate = pop;
        }
        else
        {
            _PopupIsCreate.ClosePopup();
            _PopupIsCreate = null;
            
            ExpanderText_OnMouseRightButtonDown(sender, e);
        }
    }

    private void AddNewFolder()
    {
        SelectFolder select = ClickFolder;
        
        Folder.Folder folder1 = new Folder.Folder(PackIconMaterialKind.KeyVariant, "#027AFD", "новая папка", 1, select);
        AddObjGridActive(folder1);
    }

    private void ClickFolder(Folder.Folder folder)
    {
        if (_active != null)
            _active.FolderClear();
        folder.FolderClick();
        _active = folder;
    }

    private Grid AddNewGrid()
    {
        Grid gridPanel = new Grid();

        ColumnDefinition col1 = new ColumnDefinition();
        col1.Width = new GridLength(1, GridUnitType.Star);
        
        ColumnDefinition col2 = new ColumnDefinition();
        col2.Width = new GridLength(1, GridUnitType.Star);

        gridPanel.ColumnDefinitions.Add(col1);
        gridPanel.ColumnDefinitions.Add(col2);

        Storage.Children.Add(gridPanel);
        _grids.Add(gridPanel);
        return gridPanel;
    }

    private void AddObjGrid(Folder.Folder folder)
    {
        if (_grids.Count == 0 || _grids[^1].Children.Count == 2)
        {
            if (_grids.Count == 25)
            {
                MessageBox.Show("Было превышено максимально допустимое кол-во папок", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Grid gridPanel = AddNewGrid();
            gridPanel.Children.Add(folder);
        }
        else
        {
            Grid.SetColumn(folder, 1);
            _grids[^1].Children.Add(folder);
        }
    }

    private void AddObjGridActive(Folder.Folder folder)
    {
        AddObjGrid(folder);
        
        folder.FolderClick();
        if (_active is null)
            _active = folder;
        else
        {
            _active.FolderClear();
            _active = folder;
        }
    }
    
    private void Expander_OnLoaded(object sender, RoutedEventArgs e)
    {
        SelectFolder select = ClickFolder;
        Folder.Folder folder1 = new Folder.Folder(PackIconMaterialKind.KeyVariant, "#75B2CD", "Wi-Fi", 171, select);
        Folder.Folder folder2 = new Folder.Folder(PackIconMaterialKind.KeyVariant, "#E0443E", "PassKeys", 10, select);
        Folder.Folder folder3 = new Folder.Folder(PackIconMaterialKind.KeyVariant, "#EED330", "Codes", 108, select);
        Folder.Folder folder4 = new Folder.Folder(PackIconMaterialKind.KeyVariant, "#D3992F", "Deleted", 53, select);
        
        AddObjGridActive(folder1);
        AddObjGrid(folder2);
        AddObjGrid(folder3);
        AddObjGrid(folder4);
    }
    
    
}