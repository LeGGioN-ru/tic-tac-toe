using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoadScreenPicker : EnumPicker<LoadSceenType, LoadScreen>
{
    public LoadScreenPicker(Dictionary<LoadSceenType, LoadScreen> items, Transform transform, DiContainer diContainer) : base(items, transform, diContainer)
    {
    }
}
