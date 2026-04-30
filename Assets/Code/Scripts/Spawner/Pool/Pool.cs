using System.Collections.Generic;
using UnityEngine;

public class Pool : IPool
{
    private List<GameObject> _items;

    public Pool(int size)
    {
        _items = new List<GameObject>(size);
    }

    public void Add(GameObject item)
    {
        _items.Add(item);
    }

    public bool TryGet(out GameObject item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].activeInHierarchy == false)
            {
                item = _items[i];
                return true;
            }
        }

        item = null;
        return false;
    }
}