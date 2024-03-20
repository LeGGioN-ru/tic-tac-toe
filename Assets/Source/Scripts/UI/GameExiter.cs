using UnityEngine;
using Zenject;

public class GameExiter : MonoBehaviour
{
    private PopUpPicker _popUpPicker;
    private MenuChanger _menuChanger;
    private PopUp _popUp;
    private GameInitializator _gameInitializator;

    [Inject]
    public void Construct(PopUpPicker popUpPicker, MenuChanger menuChanger, GameInitializator gameInitializator)
    {
        _gameInitializator = gameInitializator;
        _menuChanger = menuChanger;
        _popUpPicker = popUpPicker;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_menuChanger.CurrentMenuType == MenuType.MainMenu && _gameInitializator.IsGameInitializated)
                Exit();
    }

    public void Exit()
    {
        _popUp = _popUpPicker.GetItem(PopUpType.Approve);
        _popUp.Show();

        _popUp.Callback += OnCallback;
    }

    private void OnCallback(PopUpCallbackType type)
    {
        _popUp.Callback -= OnCallback;

        if (type == PopUpCallbackType.Yes)
        {
            Application.Quit();
        }

        _popUp.Hide();
    }
}
