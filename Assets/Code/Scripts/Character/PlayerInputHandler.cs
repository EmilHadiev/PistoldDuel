using System;
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
        _gun.Spawner.Spawned += OnSpawned;
    }

    private void OnDisable()
    {
        _inputService.Attacked -= Attacked;
        _gun.Spawner.Spawned -= OnSpawned;
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
        _gun.Spawner.Spawn();        
    }

    private void OnSpawned()
    {
        _gun.Sound.Play(AssetProvider.Shoot);
        _gun.View.PlayAttackAnimation();
    }
}