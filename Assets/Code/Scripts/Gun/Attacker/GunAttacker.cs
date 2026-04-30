using UnityEngine;
using Zenject;

public abstract class GunAttacker : MonoBehaviour
{
    private IInputService _input; 
    private IGunMover _mover;
    private IPlayerSoundContiner _playerSound;

    private void Awake()
    {
        var gun = GetComponent<IGun>();
        _mover = gun.Mover;
    }

    private void OnEnable()
    {
        _input.Attacked += Attack;
    }

    private void OnDisable()
    {
        _input.Attacked -= Attack;
    }

    [Inject]
    private void Constructor(IInputService input, IPlayerSoundContiner playerSoundContiner)
    {
        _input = input;
        _playerSound = playerSoundContiner;
    }

    protected virtual void Attack()
    {
        _mover.Move();
        _playerSound.Play(AssetProvider.Shoot);
    }
}