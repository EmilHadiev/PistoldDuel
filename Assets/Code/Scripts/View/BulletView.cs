using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BulletView : MonoBehaviour, IColorChangable
{
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private BulletTrail _bulletTrail;

    private void OnValidate()
    {
        _render ??= GetComponent<SpriteRenderer>();
        _bulletTrail ??= GetComponentInChildren<BulletTrail>();
    }

    public void SetColor(Color color)
    {
        _render.color = color;
        _bulletTrail.SetColor(color);
    }
}