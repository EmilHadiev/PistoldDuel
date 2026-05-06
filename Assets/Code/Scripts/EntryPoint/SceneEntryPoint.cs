using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class SceneEntryPoint : MonoBehaviour
{
    private IFactory _factory;
    private PlayerData _playerData;

    private void Awake()
    {
        CreatePlayer().Forget();
    }

    [Inject]
    private void Constructor(IFactory factory, PlayerData playerData)
    {
        _factory = factory;
        _playerData = playerData;
    }

    private async UniTask CreatePlayer()
    {
        var player = await _factory.CreateAsync(_playerData.GetPlayer());
    }
}