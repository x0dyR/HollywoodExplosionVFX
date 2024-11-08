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

    private void Awake()
    {
        _input = new InputSystem();

        _shooter = new ExplosionShooter(_explosionForce, _explosionRadius, _explosionParticle);

        _itemGrabber = new ItemGrabber(_grabRadius);
    }

    private void Update()
    {
        _currentMousePosition = _input.ReadMousePosition();

        if (_input.LeftMouseClick)
            _itemGrabber.Grab(_input.MousePositionToScreenFrom(_currentMousePosition));

        if (_input.RightMouseClick)
            _shooter.Shoot(_input.MousePositionToScreenFrom(_currentMousePosition));
    }

    private void OnDrawGizmos()
    {
        if (_input == null)
            return;

        Physics.Raycast(_input.MousePositionToScreenFrom(_currentMousePosition), out RaycastHit hit);

        Gizmos.DrawSphere(hit.point, _grabRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hit.point, _explosionRadius);
    }
}
