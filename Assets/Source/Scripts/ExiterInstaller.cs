using CustomInspector;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class ExiterInstaller : MonoInstaller
{
    [SerializeField] private TypeExit _typeExit;
    [SerializeField] private bool _needApprove;
    [ShowIfIs(nameof(_typeExit), TypeExit.MenuExit)]
    [SerializeField] private MenuType _toMenu;

    public override void InstallBindings()
    {
        switch (_typeExit)
        {
            case TypeExit.GameExit:
                Container.BindInterfacesAndSelfTo<GameExit>().AsSingle();
                break;
            case TypeExit.MenuExit:
                Container.BindInterfacesAndSelfTo<MenuExit>().AsSingle().WithArguments(_toMenu);
                break;
            default:
                throw new InvalidEnumArgumentException();
        }

        Container.BindInterfacesAndSelfTo<Exiter>().AsSingle().WithArguments(_needApprove);
    }
}
