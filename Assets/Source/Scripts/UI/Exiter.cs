using UnityEngine;
using Zenject;

public class Exiter : IActivable, ITickable, IInitializable
{
    private readonly PopUpPicker _popUpPicker;
    private readonly MenuChanger _menuChanger;
    private readonly GameInitializator _gameInitializator;
    private readonly bool _needApprove;
    private readonly IExitStrategy _exitStrategy;

    private PopUp _popUp;
    private MenuType _inMenu;

    public Exiter(PopUpPicker popUpPicker, MenuChanger menuChanger, GameInitializator gameInitializator,
        bool needApprove, IExitStrategy exitStrategy)
    {
        _exitStrategy = exitStrategy;
        _needApprove = needApprove;
        _gameInitializator = gameInitializator;
        _menuChanger = menuChanger;
        _popUpPicker = popUpPicker;
    }

    public void Initialize()
    {
        _inMenu = _menuChanger.CurrentMenuType;
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
