using UnityEngine;

public class InputSystem
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    public Vector3 ReadMousePosition()
        => Input.mousePosition;

    public Ray MousePositionToScreenFrom(Vector3 mousePosition)
        => Camera.main.ScreenPointToRay(mousePosition);

    public Vector3 MousePositionToWorldFrom(Vector3 mousePosition)
    {
        Vector3 newVector = Camera.main.ScreenToWorldPoint(mousePosition);
        newVector.y = -newVector.y;
        return newVector;
    }
    public bool LeftMouseClick
        => Input.GetMouseButton(LeftMouseButton);

    public bool RightMouseClick
        => Input.GetMouseButtonDown(RightMouseButton);
}
