using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class GunView : MonoBehaviour, IColorChangable
{
    [SerializeField] private SpriteRenderer _render;
    [Inject] private readonly GunData _gunData;

    private void OnValidate()
    {
        _render ??= GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        SetColor(_gunData.Color);
    }

    public void SetColor(Color color)
    {
        _render.color = color;
    }
}
