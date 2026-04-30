using UnityEngine;

public interface IPool
{
    void Add(GameObject item);
    bool TryGet(out GameObject item);
}