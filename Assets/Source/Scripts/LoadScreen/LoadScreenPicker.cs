using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenPicker : EnumPicker<LoadSceenType, LoadScreen>
{
    public LoadScreenPicker(Dictionary<LoadSceenType, LoadScreen> items,Transform transform) : base(items, transform)
    {
    }

}
