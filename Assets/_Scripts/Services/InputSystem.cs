using UnityEngine;

public class InputSystem
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    private Vector3 _lastMousePosition;

    public Vector3 ReadMousePosition()
        => Input.mousePosition;

    public bool LeftMousePressed()
        => Input.GetMouseButton(LeftMouseButton);

    public bool LeftMouseRelease()
        => Input.GetMouseButtonUp(LeftMouseButton);

    public bool RightMouseClick()
        => Input.GetMouseButtonDown(RightMouseButton);
}