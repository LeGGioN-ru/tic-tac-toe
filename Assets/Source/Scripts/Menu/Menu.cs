using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Menu : Screen
{
    private List<Selectable> _selectables;

    public MenuType MenuType { get; private set; }

    public void Init(MenuType menuType)
    {
        MenuType = menuType; //TODO: Возможно это плохой способ!
    }

    private void Start()
    {
        _selectables = GetComponentsInChildren<Selectable>().ToList();
    }

    public override void Show()
    {
        base.Show();
        EnableUI();
    }

    public override void Hide()
    {
        base.Hide();
        DisableUI();
    }

    public void EnableUI()
    {
        _selectables?.ForEach(x => x.interactable = true);
    }

    public void DisableUI()
    {
        _selectables?.ForEach(x => x.interactable = false);
    }
}
