using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private List<UIRow> objectRowsUI;
    [SerializeField] private Toggle _toggleAll;
    void Start()
    {
        _toggleAll.onValueChanged.AddListener(delegate { ToogleAllObjects(_toggleAll.isOn); });
    }

    public void ToogleAllObjects(bool value)
    {
        foreach (var row in objectRowsUI)
        {
            row.Toggle(value);
        }
    }
    public void ToogleAllHiddenObjects()
    {
        foreach (var row in objectRowsUI)
        {
            if (row.IsHidden)
            {
                row.Hide(false);
            }
        }
    }
    public void HideAllObjectsInsteadOf(int _objectID)
    {
        foreach (var row in objectRowsUI)
        {
            if(row.ObjectInUse != _objectID && row.IsEnabled)
            {
                row.Hide(true);
            }
        }
    }
    public void ToogleMainUI(bool value)
    {
        this.gameObject.SetActive(value);
    }
}
