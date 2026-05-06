using UnityEngine;

[RequireComponent(typeof(SawedGunBulletSpawner))]
public class SawedGun : Gun
{
    [SerializeField] private SawedGunBulletSpawner _spawner;

    public override IAmmunitionsSpawner Spawner => _spawner;
}
