using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}