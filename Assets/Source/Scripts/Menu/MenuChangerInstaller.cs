using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuChangerInstaller : MonoInstaller
{
    [SerializeField] private Button _activateButton;
    [SerializeField] private MenuType _toMenu;
    [Inject] private readonly MenuPicker _picker;

    public override void InstallBindings()
    {
        Debug.LogWarning(_picker);
        Container.BindInterfacesAndSelfTo<MenuChanger>().AsSingle().WithArguments(_picker, _toMenu, _activateButton);
    }
}
