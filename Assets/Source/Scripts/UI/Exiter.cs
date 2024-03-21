using UnityEngine;
using Zenject;

public class Exiter : IActivable,ITickable
{
    private PopUpPicker _popUpPicker;
    private MenuChanger _menuChanger;
    private PopUp _popUp;
    private bool _needApprove;
    private MenuType _inMenu;
    private IExitStrategy _exitStrategy;
    private GameInitializator _gameInitializator;

    public Exiter(PopUpPicker popUpPicker, MenuChanger menuChanger, GameInitializator gameInitializator,
        bool needApprove, MenuType inMenu, IExitStrategy exitStrategy)
    {
        _exitStrategy = exitStrategy;
        _inMenu = inMenu;
        _needApprove = needApprove;
        _gameInitializator = gameInitializator;
        _menuChanger = menuChanger;
        _popUpPicker = popUpPicker;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_menuChanger.CurrentMenuType == _inMenu && _gameInitializator.IsGameInitializated)
                TryExit();
    }

    public void TryExit()
    {
        if (_needApprove)
        {
            _popUp = _popUpPicker.GetItem(PopUpType.Approve);
            _popUp.Show();
            _popUp.Callback += OnCallback;
        }
        else
        {
            _exitStrategy.Exit();
        }

    }

    private void OnCallback(PopUpCallbackType type)
    {
        _popUp.Callback -= OnCallback;

        if (type == PopUpCallbackType.Yes)
        {
            _exitStrategy.Exit();
        }

        _popUp.Hide();
    }

    public void Activate()
    {
        TryExit();
    }
}
