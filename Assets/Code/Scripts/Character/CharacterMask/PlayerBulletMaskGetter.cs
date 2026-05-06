using UnityEngine;

public class PlayerBulletMaskGetter : BulletMaskGetter
{
    public override LayerMask GetMask()
    {
        int mask = LayerMask.NameToLayer(CustomMask.PlayerBullet);
        return mask;
    }
}
