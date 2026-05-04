using UnityEngine;
using Zenject;

public abstract class GunAttacker : MonoBehaviour
{
    private IGunMover _mover;
    private IPlayerSoundContiner _playerSound;
    private IGunView _view;

    private void Awake()
    {
        var gun = GetComponent<IGun>();
        _mover = gun.Mover;
        _view = gun.View;
    }

    [Inject]
    private void Constructor(IPlayerSoundContiner playerSoundContiner)
    {
        _playerSound = playerSoundContiner;
    }

    protected virtual void Attack()
    {
        _mover.Move();
        _playerSound.Play(AssetProvider.Shoot);
        _view.PlayAnimation();
    }
}