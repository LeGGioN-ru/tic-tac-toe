using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PopUpPicker : EnumPicker<PopUpType, PopUp>
{
    public PopUpPicker(Dictionary<PopUpType, PopUp> items, Transform itemsTransform, DiContainer diContainer, int amountItemsInPool = 1) : base(items, itemsTransform, diContainer, amountItemsInPool)
    {
    }
}
