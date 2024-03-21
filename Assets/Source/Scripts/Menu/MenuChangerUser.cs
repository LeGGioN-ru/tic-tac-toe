using UnityEngine;
using Zenject;

public class MenuChangerUser : MonoBehaviour
{
    [SerializeField] private MenuType _targetMenu;

    private MenuChanger _menuChanger;

    [Inject]
    public void Construct(MenuChanger menuChanger)
    {
        _menuChanger = menuChanger;
    }

    public void ChangeMenu()
    {
        _menuChanger.ChangeMenu(_targetMenu);
    }
}
