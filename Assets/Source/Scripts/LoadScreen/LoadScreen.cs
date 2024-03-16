using UnityEngine;

public abstract class LoadScreen : MonoBehaviour
{
    public virtual void Show()
    {
        transform.SetAsLastSibling();
    }

    public virtual void Hide()
    {
        Destroy(gameObject);
    }

    public abstract void SetProgress(float currentProgress);
}
