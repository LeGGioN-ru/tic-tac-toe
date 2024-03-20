using System;
using UnityEngine;
using Zenject;

public abstract class Screen : MonoBehaviour
{
    public Action OnShow;
    public Action OnHide;

    private IShowStrategy _showStrategy;
    private IHideStrategy _hideStrategy;

    [Inject]
    public void Construct(IShowStrategy showStrategy, IHideStrategy hideStrategy)
    {
        _showStrategy = showStrategy;
        _hideStrategy = hideStrategy;
    }

    public virtual void Show()
    {
        _showStrategy.Show(gameObject);
        OnShow?.Invoke();
    }

    public virtual void Hide()
    {
        _hideStrategy.Hide(gameObject);
        OnHide?.Invoke();
    }
}
