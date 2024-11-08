using UnityEngine;

public class ItemGrabber
{
    private Transform grabbedObject;

    public void Grab(Vector3 origin, Vector3 direction)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out DefaultBox box))
            {
                direction.y = 0;
                Debug.Log(direction);
                box.transform.forward += direction * Time.deltaTime;
            }
        }
    }
}
