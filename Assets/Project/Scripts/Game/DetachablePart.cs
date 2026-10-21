using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DetachablePart : MonoBehaviour, IActOnDeath, IResetable
{
    [SerializeField] private float _explosionForce = 3f;
    
    private Collider _collider;

    private Rigidbody _rigidbody;
    private Transform _defaultParent;
    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;

    private SkinnedMeshBaker _skinnedMeshBaker;

    private bool _wasDetached = false;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;

        if (GetComponent<Rigidbody>() != null)
            throw new System.Exception("На объекте не должно быть Rigidbody");

        if(GetComponent<SkinnedMeshRenderer>() != null)
            _skinnedMeshBaker = gameObject.AddComponent<SkinnedMeshBaker>();
            
    }

    public void Detach()
    {   
        _defaultParent = transform.parent;
        _defaultPosition = transform.localPosition;
        _defaultRotation = transform.localRotation;

        if (_skinnedMeshBaker != null)
            _skinnedMeshBaker.ShowBaked();

        _collider.enabled = true;
        transform.SetParent(null);
        _rigidbody = gameObject.AddComponent<Rigidbody>();

        float explosionForce = 500f;
        _rigidbody.AddExplosionForce(_explosionForce, _defaultParent.position, explosionForce);

        _wasDetached = true;
    }

    public void OnDied()
    {
        Detach();
    }

    public void ResetComponent()
    {
        if (_wasDetached == false)
            return;
        
        if (_skinnedMeshBaker != null)
            _skinnedMeshBaker.ShowOriginal();

        _collider.enabled = false;
        Destroy(_rigidbody);

        transform.SetParent(_defaultParent);
        transform.localRotation = _defaultRotation;
        transform.localPosition = _defaultPosition;
    }
}