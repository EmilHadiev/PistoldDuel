using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private int _damage;

    public void SetDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        gameObject.SetActive(false);
    }
}