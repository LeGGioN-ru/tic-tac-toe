using AYellowpaper.SerializedCollections;
using UnityEngine;
using Zenject;

public class GameRoot : MonoInstaller
{
    [SerializedDictionary("Screen Type", "Load Screen Prefab")]
    [SerializeField] private SerializedDictionary<LoadSceenType, LoadScreen> _loadScreens;
    [SerializeField] private CoroutineManager _coroutineManager;
    [SerializeField] private Canvas _gameCanvas;

    public override void InstallBindings()
    {
        LoadScreenPicker loadScreenPicker = new LoadScreenPicker(_loadScreens);

        Container.BindInterfacesAndSelfTo<GameInitializator>().AsSingle().WithArguments(loadScreenPicker, _gameCanvas, _coroutineManager);
    }
}
