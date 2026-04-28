using UnityEngine;

public class PistolAttacker : GunAttacker
{
    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Атака!");
    }
}