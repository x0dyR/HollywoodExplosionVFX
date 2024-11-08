using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private ParticleSystem _explosionParticle;

    private InputSystem _input;

    [SerializeField] private Vector3 _currentMousePosition;

    private ExplosionShooter _shooter;

    private void Awake()
    {
        _input = new InputSystem();

        _shooter = new ExplosionShooter(_explosionForce, _explosionRadius,_explosionParticle);
    }

    private void Update()
    {
        _currentMousePosition = _input.ReadMousePosition();

        if (_input.RightMouseClick)
        {
            _shooter.Shoot(_input.RayCastFrom(_currentMousePosition));
            Debug.Log("Shooted");
        }
    }
}
