using System;
using Zenject;

public abstract class PopUp : Screen
{
    public Action<PopUpCallbackType> Callback;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public override void Show()
    {
        base.Show();
        _signalBus.Fire(new PopUpShowed());
    }

    public override void Hide()
    {
        base.Hide();
        _signalBus.Fire(new PopUpHided());
    }
}
