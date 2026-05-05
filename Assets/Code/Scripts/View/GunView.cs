using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GunView : MonoBehaviour, IGunView
{
    private GunPrefab _gunPrefab;
    private GunData _gunData;
    private IFactory _factory;

    private void OnValidate()
    {
        _gunPrefab ??= GetComponentInChildren<GunPrefab>();
    }

    private void Awake()
    {
        CreateGunPrefab().Forget();
    }

    [Inject]
    private void Constructor(GunData gunData, IFactory factory)
    {
        _factory = factory;
        _gunData = gunData;
    }

    public void PlayAttackAnimation()
    {
        _gunPrefab.PlayAttack();
    }

    public void PlayDieAnimation()
    {
        _gunPrefab.PlayDieAnimation();
    }

    public void SetColor(Color color)
    {
        _gunPrefab.SetColor(color);
    }

    private async UniTask CreateGunPrefab()
    {
        var prefab = await _factory.CreateAsync(AssetProvider.GunDeagle);
        _gunPrefab = prefab.GetComponent<GunPrefab>();

        prefab.transform.SetParent(transform);
    }
}
