using UnityEngine;

public interface IExplosionVulnerable
{
    Rigidbody Rigidbody { get; }

    void ObtainExplosion(float explosionForce,Vector3 explosionPosition,float explosionRadius);
}
