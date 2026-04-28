using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}