using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class DefaultBox : MonoBehaviour, IGrabable, IExplosionVulnerable
{
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public Transform Transform => transform;

    public void Grab(Vector3 dragPosition)
    {
        Rigidbody.isKinematic = true;

        transform.position = new Vector3(dragPosition.x, transform.position.y, dragPosition.z);
    }

    public void Release()
        => Rigidbody.isKinematic = false;

    public void ObtainExplosion(float explosionForce, Vector3 explosionPosition, float explosionRadius)
        => Rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
}
