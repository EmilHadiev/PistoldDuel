using UnityEngine;
using Zenject;

public abstract class BulletSpawner : MonoBehaviour
{
    [SerializeField] private int _startSize = 10;
    [SerializeField] private int _additionalSize = 5;
    [SerializeField] private BulletSpawnPosition _position;

    private IFactory _factory;
    private IInputService _input;
    private BulletContainer _bulletContainer;
    private Color _bulletColor;

    private void Awake()
    {
        _bulletContainer = new BulletContainer(_factory, _startSize, _additionalSize, _bulletColor, GetMask());
    }

    private void OnEnable()
    {
        _input.Attacked += Spawn;
    }

    private void OnDisable()
    {
        _input.Attacked -= Spawn;
    }

    [Inject]
    private void Constructor(IFactory factory, IInputService input, GunData gunData)
    {
        _factory = factory;
        _input = input;
        _bulletColor = gunData.Color;
    }

    protected abstract LayerMask GetMask();

    public void Spawn()
    {
        var bullet = _bulletContainer.GetBullet();
        bullet.transform.SetPositionAndRotation(_position.transform.position, _position.transform.rotation);
        bullet.SetActive(true);
    }
}