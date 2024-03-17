using System;
using UnityEngine;

public abstract class PopUp : MonoBehaviour
{
    public Action<PopUpCallbackType> Callback;

    public virtual void Show()
    {
        transform.SetAsLastSibling();
    }

    public virtual void Hide()
    {
        Destroy(gameObject);
    }
}
