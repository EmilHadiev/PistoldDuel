using System.Collections.Generic;
using UnityEngine;

public class DieAnimationPerformer : MonoBehaviour
{
    [SerializeField] private int _explosionForce = 25;
    [SerializeField] private GameObject[] _gunElements;

    private List<Rigidbody2D> _explosionElements = new();

    public void Play()
    {
        _explosionElements.Clear();

        SetParentToAllElements(null);
        Create2DObject();
        Explode();
    }

    private void SetParentToAllElements(Transform parent)
    {
        for (int i = 0; i < _gunElements.Length; i++)
            SetParent(_gunElements[i].transform, parent);
    }

    private void SetParent(Transform obj, Transform parent)
    {
        obj.parent = parent;
    }

    private void Create2DObject()
    {
        for (int i = 0; i < _gunElements.Length; i++)
        {
            var box = new GameObject("GunPart");
            _explosionElements.Add(box.AddComponent<Rigidbody2D>());
            box.AddComponent<BoxCollider2D>();
            LayerChanger.SetLayerRecursively(box, LayerMask.NameToLayer(CustomMask.Player));

            SetParent(_gunElements[i].transform, box.transform);
            _gunElements[i].transform.SetPositionAndRotation(box.transform.position, _gunElements[i].transform.rotation);
        }
    }

    private void Explode()
    {
        for (int i = 0; i < _explosionElements.Count; i++)
        {
            _explosionElements[i].AddForce(GetRandomDirection() * _explosionForce, ForceMode2D.Impulse);
            Debug.Log("Explode");
        }
    }

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle;
    }
}