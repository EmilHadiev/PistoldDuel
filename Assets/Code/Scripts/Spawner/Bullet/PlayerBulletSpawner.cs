using UnityEngine;

public class PlayerBulletSpawner : BulletSpawner
{
    protected override LayerMask GetMask()
    {
        int mask = LayerMask.NameToLayer(CustomMask.PlayerBullet);
        return mask;
    }
}
