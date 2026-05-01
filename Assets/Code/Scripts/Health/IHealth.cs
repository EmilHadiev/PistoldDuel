using System;

public interface IHealth
{
    public event Action Died;
    public event Action DamageApllyed;

    void TakeDamage(int damage);
}