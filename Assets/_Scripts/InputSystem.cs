using UnityEngine;

public class InputSystem
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    private Vector3 _lastMousePosition;

    public Vector3 ReadMousePosition()
        => Input.mousePosition;

    public Vector3 RaycastFrom(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (_lastMousePosition != mousePosition)
        {
            Physics.Raycast(ray, out RaycastHit hitInfo);
            _lastMousePosition = hitInfo.point;
        }

        return _lastMousePosition;
    }

    public bool LeftMousePressed()
        => Input.GetMouseButton(LeftMouseButton);

    public bool RightMouseClick()
        => Input.GetMouseButtonDown(RightMouseButton);
}
