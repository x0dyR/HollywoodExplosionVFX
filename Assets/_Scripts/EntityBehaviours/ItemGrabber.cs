using UnityEngine;

public class ItemGrabber
{
    private float _grabRadius;

    private Collider[] _overlapedColliders;

    private Vector3 _lastPosition;

    public ItemGrabber(float grabRadius)
    {
        _grabRadius = grabRadius;

        _overlapedColliders = new Collider[32];
    }

    public void Grab(Vector3 direction)
    {
        if (direction == _lastPosition)
            return;

        _lastPosition = direction;

        int count = Physics.OverlapSphereNonAlloc(_lastPosition, _grabRadius, _overlapedColliders);

        for (int i = 0; i < count; i++)
        {
            Collider collider = _overlapedColliders[i];

            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                return;

            Vector3 grabbedItemPosition = new Vector3(_lastPosition.x, rigidbody.transform.position.y, _lastPosition.z);
            rigidbody.MovePosition(grabbedItemPosition);
        }
    }
}
