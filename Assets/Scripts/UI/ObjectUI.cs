using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectUI : MonoBehaviour
{
    [SerializeField] private Slider _a;
    [SerializeField] private Slider _r;
    [SerializeField] private Slider _g;
    [SerializeField] private Slider _b;

    [SerializeField] private TMP_Text _label;

    [SerializeField] private Image _previewColor;
    [SerializeField] private Button _apllyColorBTN;
    [SerializeField] private Toggle _toggle;

    [SerializeField] private ObjectSettingUp _objectSettingUp;

    private Color _color = new Color(1, 1, 1, 1);
    void Start()
    {
        _label.text = _objectSettingUp.Name;

        _a.onValueChanged.AddListener(delegate { ChangeAlfaChannel(_a.value); });
        _r.onValueChanged.AddListener(delegate { ChangeRedChannel(_r.value); ChangePreviewColor(_color); });
        _g.onValueChanged.AddListener(delegate { ChangeGreenChannel(_g.value); ChangePreviewColor(_color); });
        _b.onValueChanged.AddListener(delegate { ChangeBlueChannel(_b.value); ChangePreviewColor(_color); });

        _apllyColorBTN.onClick.AddListener(delegate { ChangeColor(_color, _a.value); });
        _toggle.onValueChanged.AddListener(delegate { ToggleVisibility(_toggle.isOn); });
    }

    public void ToggleUI(bool value)
    {
        transform.parent.gameObject.SetActive(value);
        if (value)
            ToggleVisibility(_toggle.isOn);
    }
    private void ToggleVisibility(bool value)
    {
        _objectSettingUp.ChangeVisibility(value);
    }
    private void ChangePreviewColor(Color color)
    {
        _previewColor.color = color;
    }
    private void ChangeColor(Color color, float value)
    {
        _objectSettingUp.ChangeColor(color);
        _objectSettingUp.ChangeAlfa(value);
    }
    private void ChangeAlfaChannel(float value)
    {
        _objectSettingUp.ChangeAlfa(value);
    }
    private void ChangeRedChannel(float value)
    {
        _color.r = value;
    }
    private void ChangeGreenChannel(float value)
    {
        _color.g = value;
    }
    private void ChangeBlueChannel(float value)
    {
        _color.b = value;
    }
}
