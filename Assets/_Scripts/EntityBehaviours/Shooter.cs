using UnityEngine;

public class Shooter
{
    public void Shoot(Ray ray)
    {
        Ray thisRay = ray;

        if (Physics.Raycast(thisRay, out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(10);
            }
        }
    }
}
