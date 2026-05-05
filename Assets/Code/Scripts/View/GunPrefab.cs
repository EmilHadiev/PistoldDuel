using UnityEngine;

[RequireComponent(typeof(GunAnimation))]
public class GunPrefab : MonoBehaviour
{
    [SerializeField] private GunAnimation _animation;

    private void OnValidate()
    {
        _animation ??= GetComponent<GunAnimation>();
    }

    public void PlayAttack()
    {
        _animation.PlayAttack();
    }

    public void PlayDieAnimation()
    {
        _animation.PlayDieAnimation();
    }

    public void SetColor(Color color)
    {
        Debug.Log("Try to set color " + color);
    }
}