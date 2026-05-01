using UnityEngine;
using Zenject;

public abstract class BulletSpawner : MonoBehaviour, IAmmunitionsSpawner
{
    [SerializeField] private int _startSize = 10;
    [SerializeField] private int _additionalSize = 5;
    [SerializeField] private BulletSpawnPosition _position;

    private IFactory _factory;
    private BulletContainer _bulletContainer;
    private Color _bulletColor;

    private void Awake()
    {
        _bulletContainer = new BulletContainer(_factory, _startSize, _additionalSize, _bulletColor, GetMask());
    }

    [Inject]
    private void Constructor(IFactory factory, GunData gunData)
    {
        _factory = factory;
        _bulletColor = gunData.Color;
    }

    protected abstract LayerMask GetMask();

    public void Spawn(Vector3 position = default, Quaternion rotation = default)
    {
        var bullet = _bulletContainer.GetBullet();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.SetActive(true);
    }

    public void Spawn()
    {
        var bullet = _bulletContainer.GetBullet();
        bullet.transform.SetPositionAndRotation(_position.transform.position, _position.transform.rotation);
        bullet.SetActive(true);
    }
}