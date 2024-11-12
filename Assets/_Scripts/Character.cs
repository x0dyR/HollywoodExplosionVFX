using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private float _grabRadius;

    [SerializeField] private ParticleSystem _explosionParticle;

    private Vector3 _currentMousePosition;

    private InputSystem _input;

    private Raycaster _raycaster;

    private ExplosionShooter _shooter;

    private ItemGrabber _itemGrabber;

    private void Awake()
    {
        _input = new InputSystem();

        _raycaster = new Raycaster();

        _shooter = new ExplosionShooter(_explosionForce, _explosionRadius, _explosionParticle);

        _itemGrabber = new ItemGrabber(_grabRadius);
    }

    private void Update()
    {
        _currentMousePosition = _input.ReadMousePosition();

        if (_input.LeftMousePressed())
            _itemGrabber.GrabItem(_raycaster.CameraRaycastFrom(_currentMousePosition));

        if (_input.LeftMouseRelease())
            _itemGrabber.ReleaeItem();

        if (_input.RightMouseClick())
            _shooter.Shoot(_raycaster.CameraRaycastFrom(_currentMousePosition));
    }

    private void OnDrawGizmos()
    {
        if (_input == null)
            return;

        Ray ray = new Ray(Camera.main.ScreenToWorldPoint(_currentMousePosition), Camera.main.transform.forward);

        Physics.Raycast(ray, out RaycastHit hit);

        Gizmos.DrawSphere(hit.point, _grabRadius); //grab radius gizmo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hit.point, _explosionRadius); //explosion radius gizmo
    }
}
