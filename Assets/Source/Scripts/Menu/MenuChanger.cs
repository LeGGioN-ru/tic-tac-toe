using System;
using Zenject;

public class MenuChanger : IInitializable, IDisposable
{
    private readonly MenuPicker _menuPicker;
    private readonly SignalBus _signalBus;
    private Menu _currentMenu;

    public MenuType CurrentMenuType { get; private set; }

    public MenuChanger(MenuPicker menuPicker, SignalBus signalBus)
    {
        _menuPicker = menuPicker;
        _signalBus = signalBus;
    }

    public void ChangeMenu(MenuType menuType)
    {
        Menu menu = _menuPicker.GetItem(menuType);
        _currentMenu.Hide();
        menu.Show();
        CurrentMenuType = menuType;
        _currentMenu = menu;
    }

    public void Initialize()
    {
        _currentMenu = _menuPicker.GetItem(MenuType.MainMenu);

        _signalBus.Subscribe<PopUpShowed>(() => _currentMenu.DisableUI());
        _signalBus.Subscribe<PopUpHided>(() => _currentMenu.EnableUI());
    }

    public void Dispose()
    {
        _signalBus.TryUnsubscribe<PopUpShowed>(() => _currentMenu.DisableUI());
        _signalBus.TryUnsubscribe<PopUpHided>(() => _currentMenu.EnableUI());
    }
}
