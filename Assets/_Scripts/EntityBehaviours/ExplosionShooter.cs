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

    public void Shoot(Vector3 direction)
    {
        int count = Physics.OverlapSphereNonAlloc(direction, _explosionRadius, _overlapedColliders);

        Object.Instantiate(_explosionParticle, direction, Quaternion.identity, null);

        for (int i = 0; i < count; i++)
        {
            Collider collider = _overlapedColliders[i];

            if (collider.TryGetComponent(out IExplosionVulnerable explosionVulnerableItem))
                explosionVulnerableItem.ObtainExplosion(_explosionForce, direction, _explosionRadius);
        }
    }
}