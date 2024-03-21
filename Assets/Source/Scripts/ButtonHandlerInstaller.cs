using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonHandlerInstaller : MonoInstaller
{
    [SerializeField] private Button _button;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ButtonHandler>().AsSingle().WithArguments(_button);
    }
}
