using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class GunAnimation : MonoBehaviour
{
    [Header("Ссылки на компоненты")]
    [SerializeField] private Transform _slider;          // Затвор
    [SerializeField] private Transform _trigger;       // Спусковой крючок

    [Header("Настройки затвора")]
    [SerializeField] private Vector3 _boltRecoilOffset = new Vector3(0, 0, -0.15f); // Смещение назад
    [SerializeField] private float _boltDuration = 0.04f; // Время движения назад

    [Header("Настройки крючка")]
    [SerializeField] private Vector3 _triggerRotationOffset = new Vector3(20f, 0, 0); // Поворот назад
    [SerializeField] private float _triggerDuration = 0.03f; // Время нажатия

    [Inject] private readonly IFactory _factory;

    // Сохраняем начальные локальные позиции и вращения
    private Vector3 initialBoltPosition;
    private Quaternion initialTriggerRotation;

    private Sequence shootSequence;
    private BulletSpawnPosition _bulletSpawnPosition;
    private ParticlesView _particle;

    private void Awake()
    {
        // Запоминаем исходные позиции при старте, чтобы всегда возвращаться к ним
        if (_slider != null)
            initialBoltPosition = _slider.localPosition;

        if (_trigger != null)
            initialTriggerRotation = _trigger.localRotation;

        _bulletSpawnPosition = FindAnyObjectByType<BulletSpawnPosition>();
        CreateParticle().Forget();
    }

    private void OnDestroy()
    {
        // Чистим твины из памяти при уничтожении объекта
        shootSequence?.Kill();
    }

    public void Play()
    {
        PerformAnimation();
        _particle.Play();
    }

    private void PerformAnimation()
    {
        // Проверяем, назначены ли объекты в инспекторе
        if (_slider == null || _trigger == null)
            return;

        // Если предыдущая анимация еще идет — мгновенно завершаем её.
        // true внутри Complete заставляет детали мгновенно встать на место перед удалением.
        if (shootSequence != null && shootSequence.IsActive())
        {
            shootSequence.Complete(true);
        }

        // Создаем новую последовательность
        shootSequence = DOTween.Sequence();

        // 1. Движение затвора (назад и возврат)
        Tween boltMove = GetSlideAnimation();

        // 2. Вращение крючка (назад и возврат)
        Tween triggerRotate = GetTriggerAnimation();

        // Объединяем их в одну последовательность, чтобы они выполнялись одновременно
        shootSequence.Join(boltMove);
        shootSequence.Join(triggerRotate);

        // На всякий случай гарантируем возврат в точные исходные координаты по завершении
        shootSequence.OnKill(() =>
        {
            _slider.localPosition = initialBoltPosition;
            _trigger.localRotation = initialTriggerRotation;
        });
    }

    private Tween GetTriggerAnimation()
    {
        Vector3 targetTriggerRot = initialTriggerRotation.eulerAngles + _triggerRotationOffset;
        Tween triggerRotate = _trigger.DOLocalRotate(targetTriggerRot, _triggerDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutQuad);
        return triggerRotate;
    }

    private Tween GetSlideAnimation()
    {
        Vector3 targetBoltPos = initialBoltPosition + _boltRecoilOffset;
        Tween boltMove = _slider.DOLocalMove(targetBoltPos, _boltDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutQuad);
        return boltMove;
    }

    private async UniTask CreateParticle()
    {
        var prefab = await _factory.CreateAsync(AssetProvider.ParticleShoot);
        _particle = prefab.GetComponent<ParticlesView>();
        _particle.Stop();

        var spawnPos = _bulletSpawnPosition.transform;

        _particle.transform.SetPositionAndRotation(spawnPos.position, spawnPos.rotation);
        _particle.transform.SetParent(spawnPos);
    }
}
    