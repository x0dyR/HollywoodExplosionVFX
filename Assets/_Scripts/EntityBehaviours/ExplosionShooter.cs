using UnityEngine;

public class ExplosionShooter
{
    private float _explosionForce;
    private float _explosionRadius;

    private ParticleSystem _explosionParticle;

    private Collider[] _overlapedColliders;

    public ExplosionShooter(float explosionForce, float explosionRadius, ParticleSystem explosionParticle)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;

        _explosionParticle = explosionParticle;

        _overlapedColliders = new Collider[32];
    }

    public void Shoot(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            int count = Physics.OverlapSphereNonAlloc(hit.point, _explosionRadius, _overlapedColliders);

            Object.Instantiate(_explosionParticle, hit.point, Quaternion.identity, null);

            for (int i = 0; i < count; i++)
            {
                Collider collider = _overlapedColliders[i];

                if (collider.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(_explosionForce, hit.point, _explosionRadius);
            }
        }
    }
}