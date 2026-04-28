using UnityEngine;
using Zenject;

public abstract class GunAttacker : MonoBehaviour
{
    private IInputService _input; 
    private IGunMover _mover;

    private void Awake()
    {
        var gun = GetComponent<IGun>();
        _mover = gun.Mover;
    }

    private void OnEnable()
    {
        _input.Clicked += Attack;
    }

    private void OnDisable()
    {
        _input.Clicked -= Attack;
    }

    [Inject]
    private void Constructor(IInputService input)
    {
        _input = input;
    }

    protected virtual void Attack()
    {
        _mover.Move();
    }
}