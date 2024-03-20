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
        Container.BindInterfacesAndSelfTo<DefaultHide>().AsSingle();
        Container.BindInterfacesAndSelfTo<DefaultShow>().AsSingle();

        Container.BindInterfacesAndSelfTo<LoadScreenPicker>().AsSingle().WithArguments(_loadScreens, _gameCanvas.transform);
        Container.BindInterfacesAndSelfTo<GameInitializator>().AsSingle().WithArguments(_coroutineManager);
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<PopUpShowed>();
        Container.DeclareSignal<PopUpHided>();
        Container.BindInterfacesAndSelfTo<PopUpPicker>().AsSingle().WithArguments(_popUps, _gameCanvas.transform, 3).NonLazy();
        Container.BindInitializableExecutionOrder<GameInitializator>(1);
        Container.BindInterfacesAndSelfTo<MenuPicker>().AsSingle().WithArguments(_menu).NonLazy();
        Container.BindInterfacesAndSelfTo<MenuChanger>().AsSingle();
    }
}
