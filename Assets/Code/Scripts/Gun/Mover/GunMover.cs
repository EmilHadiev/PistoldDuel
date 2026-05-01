using UnityEngine;

[RequireComponent(typeof(GunRecoiler))]
public class GunMover : MonoBehaviour, IGunMover
{
    [SerializeField] private GunRecoiler _recoiler;

    private void OnValidate()
    {
        _recoiler ??= GetComponent<GunRecoiler>();
    }

    public virtual void Move()
    {
        _recoiler.ApplyRecoil();
    }
}