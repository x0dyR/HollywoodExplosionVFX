using UnityEngine;

public class InputSystem
{
    private const int LeftMouseButton = 0;

    public Vector3 ReadMousePosition()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton) == false)
            return Vector3.zero;

        return Input.mousePosition;
    }
}
