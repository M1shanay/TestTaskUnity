using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRow : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private ObjectSettingUp _object;
    [SerializeField] private ObjectUI _objectUI;
    private Toggle _toggle;
    private bool _hidden = false;
    public int ObjectInUse { get { return _object.objectID; } }
    public bool IsEnabled { get { return _toggle.isOn; } }
    public bool IsHidden { get { return _hidden; } }
    private void Start()
    {
        _name.text = _object.Name;
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(delegate { ToggleVisibility(_toggle.isOn);});
    }
    private void ToggleVisibility(bool value)
    {
        _object.ChangeVisibility(value);
        _objectUI.ToggleUI(value);
    }
    public void Toggle(bool value)
    {
        _toggle.isOn = value;
    }
    public void Hide(bool value)
    {
        if (!_hidden)
           _toggle.isOn = false;
        else
           _toggle.isOn = true;

        _hidden = value;
    }
}
