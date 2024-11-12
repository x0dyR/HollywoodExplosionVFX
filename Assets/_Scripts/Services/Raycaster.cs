using UnityEngine;

public class Raycaster
{
    private Vector3 _lastPosition;

    public Vector3 CameraRaycastFrom(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);

        if (_lastPosition != screenPoint)
        {
            Physics.Raycast(ray, out RaycastHit hitInfo);
            _lastPosition = hitInfo.point;
        }

        return _lastPosition;
    }
}
