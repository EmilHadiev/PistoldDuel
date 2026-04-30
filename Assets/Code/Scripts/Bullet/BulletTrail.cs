using UnityEngine;


[RequireComponent(typeof(TrailRenderer))]
public class BulletTrail : MonoBehaviour, IColorChangable
{
    [SerializeField] private TrailRenderer _renderer;

    private void OnValidate()
    {
        _renderer ??= GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        _renderer.Clear();
    }

    public void SetColor(Color color)
    {
        _renderer.startColor = color;
        _renderer.endColor = color;
    }

    [ContextMenu(nameof(SetOptions))]
    private void SetOptions()
    {
        _renderer.time = 0.3f;
        _renderer.minVertexDistance = 0.1f;
        _renderer.startWidth = 1;
        _renderer.endWidth = 0;
        _renderer.textureMode = LineTextureMode.Stretch;
        _renderer.alignment = LineAlignment.View;
        _renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        _renderer.receiveShadows = false;
        _renderer.numCornerVertices = 4;
        _renderer.numCapVertices = 5;
    }
}