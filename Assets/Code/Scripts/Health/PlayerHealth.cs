using Zenject;

public class PlayerHealth : Health
{
    [Inject] private readonly PlayerData _playerData;

    protected override void SetHealthPoints()
    {
        HealthPoints = _playerData.Health;
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }
}