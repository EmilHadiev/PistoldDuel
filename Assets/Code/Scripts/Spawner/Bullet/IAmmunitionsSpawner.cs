using UnityEngine;

public interface IAmmunitionsSpawner
{
    void Spawn();
    void Spawn(Vector3 position = default, Quaternion rotation = default);
}