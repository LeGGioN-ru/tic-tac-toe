using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPicker : EnumPicker<PopUpType, PopUp>
{
    public PopUpPicker(Dictionary<PopUpType, PopUp> items, Transform itemsTransform, int amountItemsInPool = 1) : base(items, itemsTransform, amountItemsInPool)
    {
    }
}
