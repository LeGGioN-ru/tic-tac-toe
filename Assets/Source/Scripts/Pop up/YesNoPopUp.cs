using UnityEngine;
using UnityEngine.UI;

public class YesNoPopUp : PopUp
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(OnYes);
        _noButton.onClick.AddListener(OnNo);
    }

    private void OnDisable()
    {
        _noButton.onClick.RemoveListener(OnNo);
        _yesButton.onClick.RemoveListener(OnYes);
    }

    public void OnYes()
    {
        Callback?.Invoke(PopUpCallbackType.Yes);
    }

    public void OnNo()
    {
        Callback?.Invoke(PopUpCallbackType.No);
    }
}
