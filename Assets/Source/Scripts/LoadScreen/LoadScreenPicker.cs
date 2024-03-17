using AYellowpaper.SerializedCollections;
using UnityEngine;

public class LoadScreenPicker : EnumPicker<LoadSceenType, LoadScreen>
{
    public LoadScreenPicker(SerializedDictionary<LoadSceenType, LoadScreen> items,Transform transform) : base(items, transform)
    {
    }

}
