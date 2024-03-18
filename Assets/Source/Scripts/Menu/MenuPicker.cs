using System.Collections.Generic;

public class MenuPicker : EnumPicker<MenuType, Menu>
{
    private Menu _currentMenu;

    public MenuPicker(Dictionary<MenuType, Menu> items) : base(items)
    {
        _currentMenu = GetItem(MenuType.MainMenu);
    }

    public void ChangeMenu(MenuType menuType)
    {
        Menu menu = GetItem(menuType);
        _currentMenu.DisableMenu();
        menu.EnableMenu();
        _currentMenu = menu;
    }
}
