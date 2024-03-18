using System;
using UnityEngine;

public abstract class PopUp : MonoBehaviour
{
    public Action<PopUpCallbackType> Callback;

    public virtual void Show()
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
