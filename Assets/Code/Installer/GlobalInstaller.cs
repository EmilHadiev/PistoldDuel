using Zenject;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private PlayerSoundContainer _playerSound;
    [SerializeField] private GunData _gunData;

    public override void InstallBindings()
    {
        BindAddressables();
        BindSoundContainer();
        BindGunData();
    }

    private void BindAddressables()
    {
        Container.BindInterfacesTo<AddressablesLoader>().AsSingle();
    }

    private void BindSoundContainer()
    {
        Container.BindInterfacesTo<PlayerSoundContainer>().FromComponentInNewPrefab(_playerSound).AsSingle();
    }

    private void BindGunData()
    {
        Container.Bind<GunData>().FromNewScriptableObject(_gunData).AsSingle();
    }
}