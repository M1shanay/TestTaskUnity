using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private CameraUI _ui;
    private ObjectInspection _focusedObject;

    [SerializeField] private float _top;
    [SerializeField] private float _bottom;
    [SerializeField] private float _left;
    [SerializeField] private float _right;

    [SerializeField] private float _defaultZoom = 4;
    [SerializeField] private float _focusedZoom = 2;

    private bool _focused = false;
    private bool _zoomed = false;

    public bool IsFocused { get { return _focused; } }

    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (_focused)
        {
            FocusOnObject();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        if (!_focused)
        {
            if ((Input.mousePosition.x <= Screen.width * _left) && (Input.mousePosition.x >= Screen.width * _right))
            {
                if (Input.mousePosition.y >= Screen.height * _top)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up, Time.deltaTime * 1f);
                }
                if (Input.mousePosition.y <= Screen.height * _bottom)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down, Time.deltaTime * 1f);
                }
            }
        }
    }
    public void FocusOnObject()
    {
        if (!FocusDistance())
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _focusedObject.transform.position.y, transform.position.z), Time.deltaTime * 3f);
        }
        else
        {
            if (!_zoomed)
            {
                _camera.orthographicSize = _focusedZoom;
                _zoomed = true;
            }
            else
            {
                Zoom();
                if (Input.GetMouseButtonDown(1))
                {
                    _zoomed = false;
                    _focused = false;
                    _focusedObject.NotFocusedOn();
                    _ui.ToogleMainUI(true);
                    _ui.ToogleAllHiddenObjects();
                    _focusedObject = null;
                    _camera.orthographicSize = _defaultZoom;
                }
            }
        }
    }
    public void Zoom()
    {
        _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
    public bool FocusDistance()
    {
        if (transform.position.y <= _focusedObject.transform.position.y +0.1f && transform.position.y >= _focusedObject.transform.position.y - 0.1f)
            return true;
        return false;
    }
    public void SetFocus(ObjectInspection _object, int _objectID)
    {
        _ui.HideAllObjectsInsteadOf(_objectID);
        _ui.ToogleMainUI(false);
        //_ui.HideAllObjectsInsteadOf(_objectID);
        _focusedObject = _object;
        _focused = true;
    }
}
