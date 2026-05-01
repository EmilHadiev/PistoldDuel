using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class BulletContainer
{
    private readonly LayerMask _mask;
    private readonly IFactory _factory;
    private readonly IPool _pool;
    private readonly int _startSize;
    private readonly int _additionalSize;
    private readonly Color _bulletColor;

    public BulletContainer(IFactory factory, int startSize, int additionalSize, Color color, LayerMask mask)
    {
        _factory = factory;
        _startSize = startSize;
        _additionalSize = additionalSize;
        _mask = mask;
        _bulletColor = color;
        _pool = new Pool(startSize);

        Create(_startSize).Forget();
    }

    public GameObject GetBullet()
    {
        GameObject bullet;

        if (TryGetBullet(out bullet))
        {
            return bullet;
        }
        else
        {
            Create(_additionalSize).Forget();

            if (TryGetBullet(out bullet))
                return bullet;
        }

        throw new ArgumentNullException(nameof(bullet));
    }

    private bool TryGetBullet(out GameObject bullet)
    {
        return _pool.TryGet(out bullet);
    }

    private async UniTask Create(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject bullet = await _factory.CreateAsync(AssetProvider.Bullet);
            bullet.gameObject.SetActive(false);
            ChangeBulletLayer(bullet, _mask);

            if (bullet.TryGetComponent(out IColorChangable colorChanger))
                colorChanger.SetColor(_bulletColor);



            _pool.Add(bullet);
        }
    }

    private void ChangeBulletLayer(GameObject bullet, LayerMask mask)
    {
        LayerChanger.SetLayerRecursively(bullet, mask);
    }
}