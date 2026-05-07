using UnityEngine;

public class SawedGunBulletSpawner : BulletSpawner
{
    [SerializeField] private float _shootDelay = 1f;

    private float _currentTime;
    private bool _isReady;

    private void Update()
    {
        if (_currentTime >= _shootDelay)
            _isReady = true;
        else
            _currentTime += Time.deltaTime;
    }

    public override void Spawn()
    {
        if (_isReady)
        {
            base.Spawn();
            _isReady = false;
            _currentTime = 0;
        }
    }    
}