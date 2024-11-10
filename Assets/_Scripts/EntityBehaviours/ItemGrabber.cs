using UnityEngine;

public class ItemGrabber
{
    private float _grabRadius;

    private Collider[] _overlapedColliders;

    public ItemGrabber(float grabRadius)
    {
        _grabRadius = grabRadius;

        _overlapedColliders = new Collider[32];
    }

    public void Grab(Vector3 direction)
    {
        int count = Physics.OverlapSphereNonAlloc(direction, _grabRadius, _overlapedColliders);

        for (int i = 0; i < count; i++)
        {
            Collider collider = _overlapedColliders[i];

            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                return;

            Vector3 grabbedItemPosition = new Vector3(direction.x, rigidbody.transform.position.y, direction.z);
            rigidbody.MovePosition(grabbedItemPosition);
        }
    }
}
