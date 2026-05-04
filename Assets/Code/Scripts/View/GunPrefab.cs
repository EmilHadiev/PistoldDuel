using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(GunAnimation))]
public class GunPrefab : MonoBehaviour
{
    [SerializeField] private GunAnimation _animation;

    private void OnValidate()
    {
        _animation ??= GetComponent<GunAnimation>();
    }

    public void PlayAnimation()
    {
        _animation.Play();
    }

    public void SetColor(Color color)
    {
        Debug.Log("Try to set color " + color);
    }
}