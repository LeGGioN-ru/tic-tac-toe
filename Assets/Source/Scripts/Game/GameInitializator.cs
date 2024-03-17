using System.Collections;
using UnityEngine;
using Zenject;

public class GameInitializator : IInitializable
{
    private readonly LoadScreenPicker _loadScreenPicker;
    private readonly CoroutineManager _coroutineManager;

    private LoadScreen _loadScreen;
    private const float _loadGameTime = 2f;
    private const int _amountPartLoad = 8;
    private const float _afterLoadWaitTime = 0.25f;

    public GameInitializator(LoadScreenPicker loadScreenPicker, CoroutineManager coroutineManager)
    {
        _loadScreenPicker = loadScreenPicker;
        _coroutineManager = coroutineManager;
    }

    public void Initialize()
    {
        _loadScreen = _loadScreenPicker.GetItem(LoadSceenType.DefaultLoadScreen);
        _loadScreen.Show();
        _coroutineManager.StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        for (int i = 0; i <= _amountPartLoad; i++)
        {
            yield return new WaitForSeconds(_loadGameTime / _amountPartLoad);
            _loadScreen.SetProgress((float)i / _amountPartLoad);
        }

        yield return new WaitForSeconds(_afterLoadWaitTime);

        _loadScreen.Hide();
    }
}
