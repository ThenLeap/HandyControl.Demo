using System.Collections.ObjectModel;

namespace HandyControl.Demo.SideMenu.Models;

public class MenuItemModel
{
    public string Header { get; set; }
    public string Tag { get; set; }
    public string Icon { get; set; }  // 存放 Segoe MDL2 Assets 的 Unicode
    public ObservableCollection<MenuItemModel> Children { get; set; } = new();
}
