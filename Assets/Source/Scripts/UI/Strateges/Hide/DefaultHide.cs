using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHide : IHideStrategy
{
    public void Hide(GameObject hideObject)
    {
        hideObject.SetActive(false);
    }
}
