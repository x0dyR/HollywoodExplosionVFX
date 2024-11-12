using UnityEngine;

public class ItemGrabber
{
    private IGrabable _grabbedItem;

    private float _grabRadius;

    private Collider[] _overlapedColliders;

    public ItemGrabber(float grabRadius)
    {
        _grabRadius = grabRadius;

        _overlapedColliders = new Collider[32];
    }

    public void GrabItem(Vector3 direction)
    {
        int count = Physics.OverlapSphereNonAlloc(direction, _grabRadius, _overlapedColliders);

        for (int i = 0; i < count; i++)
        {
            Collider collider = _overlapedColliders[i];

            if (collider.TryGetComponent(out IGrabable grabableItem) == false)
                return;

            _grabbedItem = grabableItem;
            grabableItem.Grab(direction);
        }
    }

    public void ReleaeItem()
    {
        _grabbedItem.Release();
    }
}
