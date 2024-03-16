using AYellowpaper.SerializedCollections;
using UnityEngine;

public class LoadScreenPicker : EnumPicker<LoadSceenType, LoadScreen>
{
    public LoadScreenPicker(SerializedDictionary<LoadSceenType, LoadScreen> items) : base(items)
    {
    }

    public LoadScreen ShowScreen(LoadSceenType loadSceenType, Canvas canvas)
    {
        LoadScreen loadScreen = GameObject.Instantiate(GetItem(loadSceenType), canvas.transform);
        
        loadScreen.Show();
        return loadScreen;
    }
}
