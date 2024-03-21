using System.Collections.Generic;

public class MenuPicker : EnumPicker<MenuType, Menu>
{
    public MenuPicker(Dictionary<MenuType, Menu> items) : base(items)
    {
        foreach (var item in items)
            item.Value.Init(item.Key);
    }
}
