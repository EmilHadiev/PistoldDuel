using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Столкновение!");
        gameObject.SetActive(false);
    }
}