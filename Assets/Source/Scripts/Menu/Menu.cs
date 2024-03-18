using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private List<Selectable> _selectables;

    private void Start()
    {
        _selectables = GetComponentsInChildren<Selectable>().ToList();
    }

    public void EnableMenu()
    {
        gameObject.SetActive(true);
        EnableUI();
    }

    public void DisableMenu()
    {
        gameObject.SetActive(false);
        DisableUI();
    }

    public void EnableUI()
    {
        _selectables?.ForEach(x => x.interactable = true);
    }

    public void DisableUI()
    {
        _selectables?.ForEach(x => x.interactable = false);
    }
}
