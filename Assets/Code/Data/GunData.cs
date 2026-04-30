using UnityEngine;

[CreateAssetMenu(menuName = "Data/GunData", fileName = "GunData")]
public class GunData : ScriptableObject
{
    [SerializeField] public Color Color;
}