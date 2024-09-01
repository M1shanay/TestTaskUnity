using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInspection : MonoBehaviour
{
    [SerializeField] private ObjectUI _objectUI;
    private int _objectID;
    private CameraMovement _mainCamera;

    private bool _selected = false;
    private Vector3 _origin;

    public float rotationSpeed;

    void Start()
    {
        _mainCamera = Camera.main.GetComponent<CameraMovement>();
        _objectID = GetComponent<ObjectSettingUp>().objectID;
        _origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
        if (_selected)
        {
            Rotate();
            IsSelected();
        }
    }
    public void OnMouseOver()
    {
        if (!_selected && Input.GetMouseButtonDown(0))
        {
            if (!_mainCamera.IsFocused)
            {
                _mainCamera.SetFocus(this, _objectID);
                _objectUI.ToggleUI(false);
                
            }
            _selected = true;
        }
    }
    private void Rotate()
    {
        this.transform.RotateAround(_origin, Vector3.up, -Input.GetAxis("Mouse X") * rotationSpeed);
        this.transform.RotateAround(_origin, Vector3.right, Input.GetAxis("Mouse Y") * rotationSpeed);

    }
    private void IsSelected()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _selected = false;
        }
    }
    public void NotFocusedOn()
    {
        _objectUI.ToggleUI(true);
    }
}
