using UnityEngine;
using UnityEngine.UI;

public class DefaultLoadScreen : LoadScreen
{
    [SerializeField] private Slider _progressBar;

    public override void SetProgress(float currentProgress)
    {
        _progressBar.value = currentProgress;
    }
}
