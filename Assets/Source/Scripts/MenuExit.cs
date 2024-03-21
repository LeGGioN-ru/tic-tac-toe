public class MenuExit : IExitStrategy
{
    private readonly MenuType _targetMenu;
    private readonly MenuChanger _menuChanger;

    public MenuExit(MenuType targetMenu, MenuChanger menuChanger)
    {
        _targetMenu = targetMenu;
        _menuChanger = menuChanger;
    }

    public void Exit()
    {
        _menuChanger.ChangeMenu(_targetMenu);
    }
}
