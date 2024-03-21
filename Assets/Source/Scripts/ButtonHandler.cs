using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Zenject;

public class ButtonHandler : IInitializable, IDisposable
{
    private readonly Button _button;
    private readonly IActivable _activable;

    public ButtonHandler(Button button, IActivable activable)
    {
        _button = button;
        _activable = activable;
    }

    public void Initialize()
    {
        _button.onClick.AddListener(_activable.Activate);
    }

    public void Dispose()
    {
        _button.onClick.RemoveListener(_activable.Activate);
    }
}
