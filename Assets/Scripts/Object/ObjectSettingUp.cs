using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSettingUp : MonoBehaviour
{
    [SerializeField] private string _objectName;
    [SerializeField] private int _objectID;
    private Material _objectMaterail;
    private Renderer _objectRenderer;

    public int objectID { get { return _objectID; } }
    public string Name { get { return _objectName; } }
    void Start()
    {
        _objectRenderer = GetComponent<Renderer>();
        _objectMaterail = _objectRenderer.material;
    }

    public void ChangeColor(Color _color)
    {
        _objectMaterail.color = _color;
    }
    public void ChangeAlfa(float _alfa)
    {
        var oldColor = _objectMaterail.color;
        _objectMaterail.color = new Color(oldColor.r, oldColor.g, oldColor.b, _alfa);
    }
    public void ChangeVisibility(bool _enabled)
    {
        _objectRenderer.enabled = _enabled;
        this.gameObject.SetActive(_enabled);
    }
}
