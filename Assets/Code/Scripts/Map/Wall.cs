using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Wall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _initialPushForce = 10f;
    [Range(0.1f, 0.9f),SerializeField] private float _reductionFactor = 0.7f;
    [SerializeField] private float _minForceThreshold = 1f;

    private float _currentPushForce;
    private IInputService _input;

    private void Awake()
    {
        // Устанавливаем начальное значение при старте
        _currentPushForce = _initialPushForce;
    }

    private void OnEnable()
    {
        _input.Attacked += ResetWall;
    }

    private void OnDisable()
    {
        _input.Attacked -= ResetWall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null && _currentPushForce >= _minForceThreshold)
        {
            // Получаем точку контакта
            ContactPoint2D contact = collision.contacts[0];

            // Нормаль направлена ОТ игрока К стене. 
            // Инвертируем её (-contact.normal), чтобы получить направление ОТ стены К игроку.
            Vector2 pushDirection = -contact.normal;

            PushPlayer(collision.rigidbody, pushDirection);
            ReduceForce();
        }
    }    

    [Inject]
    private void Constructor(IInputService inputService)
    {
        _input = inputService;
    }

    private void PushPlayer(Rigidbody2D player, Vector2 direction)
    {
        player.AddForce(direction * _currentPushForce, ForceMode2D.Impulse);
    }

    private void ReduceForce()
    {
        _currentPushForce *= _reductionFactor;

        if (_currentPushForce < _minForceThreshold)
        {
            _currentPushForce = 0;
        }
    }

    private void ResetWall()
    {
        _currentPushForce = _initialPushForce;
    }
}