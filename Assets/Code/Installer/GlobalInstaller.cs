using Zenject;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private PlayerSoundContainer _playerSound;
    [SerializeField] private GunData _gunData;
    [SerializeField] private PlayerData _playerData;

    public override void InstallBindings()
    {
        BindAddressables();
        BindSoundContainer();
        BindData();
    }

    private void BindAddressables()
    {
        Container.BindInterfacesTo<AddressablesLoader>().AsSingle();
    }

    private void BindSoundContainer()
    {
        Container.BindInterfacesTo<PlayerSoundContainer>().FromComponentInNewPrefab(_playerSound).AsSingle();
    }

    private void BindData()
    {
        Container.Bind<GunData>().FromNewScriptableObject(_gunData).AsSingle();
        Container.Bind<PlayerData>().FromNewScriptableObject(_playerData).AsSingle();
    }
}