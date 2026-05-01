using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
}
