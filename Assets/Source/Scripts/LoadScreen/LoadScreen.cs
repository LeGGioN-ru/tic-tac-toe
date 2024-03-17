using UnityEngine;

public abstract class LoadScreen : MonoBehaviour
{
    public virtual void Show()
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public abstract void SetProgress(float currentProgress);
}
