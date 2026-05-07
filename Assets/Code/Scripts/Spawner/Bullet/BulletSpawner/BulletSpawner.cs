using System;
using UnityEngine;
using Zenject;

public abstract class BulletSpawner : MonoBehaviour, IAmmunitionsSpawner
{
    [SerializeField] private int _startSize = 10;
    [SerializeField] private int _additionalSize = 5;
    [SerializeField] private BulletSpawnPosition[] _positions;
    [SerializeField] private BulletMaskGetter _maskGetter;

    private IFactory _factory;
    private BulletContainer _bulletContainer;
    private Color _bulletColor;

    public event Action Spawned;

    private void OnValidate()
    {
        _maskGetter ??= GetComponent<BulletMaskGetter>();
        
        if (_positions.Length == 0)
            _positions ??= GetComponentsInChildren<BulletSpawnPosition>();
    }

    private void Awake()
    {
        _bulletContainer = new BulletContainer(_factory, _startSize, _additionalSize, _bulletColor, _maskGetter.GetMask());
    }

    [Inject]
    private void Constructor(IFactory factory, GunData gunData)
    {
        _factory = factory;
        _bulletColor = gunData.Color;
    }

    public virtual void Spawn()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            var pos = _positions[i].transform;
            var bullet = _bulletContainer.GetBullet();
            bullet.transform.SetPositionAndRotation(pos.position, pos.rotation);
            bullet.SetActive(true);
        }

        Spawned?.Invoke();
    }
}