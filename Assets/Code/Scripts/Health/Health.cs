using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    protected int HealthPoints;

    public event Action Died;
    public event Action DamageApllyed;

    private void Awake()
    {
        SetHealthPoints();
    }

    public void TakeDamage(int damage)
    {
        int result = HealthPoints - damage;

        if (result <= 0)
            Die();
        else
            DamageApllyed?.Invoke();
    }

    protected abstract void SetHealthPoints();

    protected virtual void Die()
    {
        Died?.Invoke();
    }
}