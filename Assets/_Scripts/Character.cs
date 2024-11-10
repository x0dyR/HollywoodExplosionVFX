using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private float _grabRadius;

    [SerializeField] private ParticleSystem _explosionParticle;

    private InputSystem _input;

    [SerializeField] private Vector3 _currentMousePosition;

    private ExplosionShooter _shooter;

    private ItemGrabber _itemGrabber;

    private bool _isGrabbing;
    private bool _isShooting;

    private void Awake()
    {
        _input = new InputSystem();

        _shooter = new ExplosionShooter(_explosionForce, _explosionRadius, _explosionParticle);

        _itemGrabber = new ItemGrabber(_grabRadius);
    }

    private void Update()
    {
        _currentMousePosition = _input.ReadMousePosition();

        if (_input.LeftMousePressed())
            _itemGrabber.Grab(_input.RaycastFrom(_currentMousePosition));


        if (_input.RightMouseClick())
            _shooter.Shoot(_input.RaycastFrom(_currentMousePosition));

        Debug.DrawRay(_input.ReadMousePosition(), Camera.main.transform.forward * 100);
    }
}
