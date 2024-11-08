using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private ParticleSystem _explosionParticle;

    private InputSystem _input;

    [SerializeField] private Vector3 _currentMousePosition;

    private ExplosionShooter _shooter;

    private ItemGrabber _itemGrabber;

    private void Awake()
    {
        _input = new InputSystem();

        _shooter = new ExplosionShooter(_explosionForce, _explosionRadius, _explosionParticle);

        _itemGrabber = new ItemGrabber();
    }

    private void Update()
    {
        _currentMousePosition = _input.ReadMousePosition();

        if (_input.LeftMouseClick)
            _itemGrabber.Grab(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward * 100);

        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward * 100);

        if (_input.RightMouseClick)
            _shooter.Shoot(_input.MousePositionToScreenFrom(_currentMousePosition));
    }

}
