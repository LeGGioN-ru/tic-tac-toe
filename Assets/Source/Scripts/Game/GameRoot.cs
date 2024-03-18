using AYellowpaper.SerializedCollections;
using UnityEngine;
using Zenject;

public class GameRoot : MonoInstaller
{
    [SerializedDictionary("Screen Type", "Load Screen Prefab")]
    [SerializeField] private SerializedDictionary<LoadSceenType, LoadScreen> _loadScreens;
    [SerializedDictionary("Pop Up Type", "Pop Up")]
    [SerializeField] private SerializedDictionary<PopUpType, PopUp> _popUps;
    [SerializedDictionary("Menu Type", "Menu")]
    [SerializeField] private SerializedDictionary<MenuType, Menu> _menu;
    [SerializeField] private CoroutineManager _coroutineManager;
    [SerializeField] private Canvas _gameCanvas;

    public override void InstallBindings()
    {
        LoadScreenPicker loadScreenPicker = new LoadScreenPicker(_loadScreens, _gameCanvas.transform);
        Container.BindInterfacesAndSelfTo<GameInitializator>().AsSingle().WithArguments(loadScreenPicker, _coroutineManager);

        PopUpPicker popUpPicker = new PopUpPicker(_popUps, _gameCanvas.transform);
        MenuPicker menuPicker = new MenuPicker(_menu);

        Container.BindInstance(menuPicker);
    }
}
