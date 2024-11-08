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

    public void Grab(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            int count = Physics.OverlapSphereNonAlloc(hit.point, _grabRadius, _overlapedColliders);

            for (int i = 0; i < count; i++)
            {
                Collider collider = _overlapedColliders[i];

                if (collider.TryGetComponent(out DefaultBox box))
                {
                    hit.point = new Vector3(hit.point.x, box.transform.position.y, hit.point.z);
                    box.transform.position = hit.point;
                }
            }
        }
    }
}
