using Cysharp.Threading.Tasks;
using Zenject;

public class PlayerHealth : Health
{
    [Inject] private readonly PlayerData _playerData;
    private IGunView _gunView;

    private void Start()
    {
        _gunView = GetComponent<IGun>().View;
        AttackPlayer().Forget();
    }

    protected override void SetHealthPoints()
    {
        HealthPoints = _playerData.Health;
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
        _gunView.PlayDieAnimation();
    }

    private async UniTask AttackPlayer()
    {
        await UniTask.Delay(3000);
        //TakeDamage(5);
    }
}