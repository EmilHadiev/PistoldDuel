using UnityEngine;

[RequireComponent(typeof(PistolBulletSpawner))]
public class Pistol : Gun
{
    [SerializeField] private BulletSpawner _spawner;

    private void OnValidate()
    {
        _spawner ??= GetComponent<BulletSpawner>();
    }

    public override IAmmunitionsSpawner Spawner => _spawner;
}