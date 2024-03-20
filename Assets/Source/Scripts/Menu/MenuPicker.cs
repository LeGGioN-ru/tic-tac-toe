using System;
using System.Collections.Generic;
using Zenject;

public class MenuPicker : EnumPicker<MenuType, Menu>
{
    private readonly SignalBus _signalBus;

    public MenuPicker(Dictionary<MenuType, Menu> items, SignalBus signalBus) : base(items)
    {
        _signalBus = signalBus;
    }
}
