using UnityEngine;
using Zenject;

public class PlayerInputHandler : MonoBehaviour
{
    private IInputService _inputService;
    private IPlayerSoundContiner _soundContiner;
    private IGun _gun;

    private void Awake()
    {
        _gun = GetComponent<Gun>();
        _gun.Sound.Init(_soundContiner);
    }

    private void OnEnable()
    {
        _inputService.Attacked += Attacked;
    }

    private void OnDisable()
    {
        _inputService.Attacked -= Attacked;
    }

    [Inject]
    private void Constructor(IInputService inputService, IPlayerSoundContiner playerSoundContiner)
    {
        _inputService = inputService;
        _soundContiner = playerSoundContiner;
    }

    private void Attacked()
    {
        _gun.Mover.Move();
        _gun.Sound.Play(AssetProvider.Shoot);
        _gun.Spawner.Spawn();
        _gun.View.PlayAttackAnimation();
    }
}