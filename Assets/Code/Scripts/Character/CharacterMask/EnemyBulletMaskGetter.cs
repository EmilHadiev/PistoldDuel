using UnityEngine;

public class EnemyBulletMaskGetter : BulletMaskGetter
{
    public override LayerMask GetMask()
    {
        int mask = LayerMask.NameToLayer(CustomMask.EnemyBullet);
        return mask;
    }
}