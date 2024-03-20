using UnityEngine;

public class DefaultShow : IShowStrategy
{
    public void Show(GameObject showObject)
    {
        showObject.transform.SetAsLastSibling();
        showObject.SetActive(true);
    }
}
