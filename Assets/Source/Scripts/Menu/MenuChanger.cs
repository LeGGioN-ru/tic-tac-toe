using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuChanger : IDisposable, IInitializable
{
    private readonly Button _button;
    private readonly MenuPicker _menuPicker;
    private readonly MenuType _menuType;

    public MenuChanger(MenuPicker menuPicker, MenuType menuType, Button button)
    {
        _menuPicker = menuPicker;
        _button = button;
        _menuType = menuType;
    }

    public void Dispose()
    {
        _button.onClick.RemoveListener(ChangeMenu);
    }

    public void Initialize()
    {
        Debug.Log("aaa");
        _button.onClick.AddListener(ChangeMenu);
    }

    public void ChangeMenu()
    {
        _menuPicker.ChangeMenu(_menuType);
    }
}
