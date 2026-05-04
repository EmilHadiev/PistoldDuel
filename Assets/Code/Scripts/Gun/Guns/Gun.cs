using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(GunMover))]
[RequireComponent(typeof(GunView))]
[RequireComponent(typeof(GunSound))]
public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField] private GunMover _mover;
    [SerializeField] private GunSound _sound;
    [SerializeField] private GunView _view;

    private void OnValidate()
    {
        _mover ??= GetComponent<GunMover>();
        _sound ??= GetComponent<GunSound>();
        _view ??= GetComponent<GunView>();
    }

    public IGunMover Mover => _mover;
    public IGunSound Sound => _sound;
    public IGunView View => _view;

    public abstract IAmmunitionsSpawner Spawner { get; }
}