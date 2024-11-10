using UnityEngine;

public class ExplosionShooter
{
    private float _explosionForce;
    private float _explosionRadius;

    private ParticleSystem _explosionParticle;

    private Collider[] _overlapedColliders;

    private Vector3 _lastPosition;

    public ExplosionShooter(float explosionForce, float explosionRadius, ParticleSystem explosionParticle)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;

        _explosionParticle = explosionParticle;

        _overlapedColliders = new Collider[32];
    }

    public void Shoot(Vector3 direction)
    {
        if (direction == _lastPosition)
            return;

        _lastPosition = direction;

        int count = Physics.OverlapSphereNonAlloc(_lastPosition, _explosionRadius, _overlapedColliders);

        Object.Instantiate(_explosionParticle, _lastPosition, Quaternion.identity, null);

        for (int i = 0; i < count; i++)
        {
            Collider collider = _overlapedColliders[i];

            if (collider.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, _lastPosition, _explosionRadius);
        }
    }
}