using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(GunMover))]
[RequireComponent(typeof(GunView))]
public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField] private GunMover _mover;

    private void OnValidate()
    {
        _mover ??= GetComponent<GunMover>();
    }

    public IGunMover Mover => _mover;
}