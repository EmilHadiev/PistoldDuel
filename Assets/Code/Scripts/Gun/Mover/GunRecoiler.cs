using UnityEngine;

public class GunRecoiler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;

    [Header("Настройки сил")]
    [SerializeField] private float _leftForce = 25f;
    [SerializeField] private float _torque = 30f;

    [Header("Динамическая высота")]
    [SerializeField] private float _minUpForce = 5f;
    [SerializeField] private float _maxUpForce = 25f;
    [SerializeField] private float _lowerY = -5f;
    [SerializeField] private float _upperY = 10f;


    private void OnValidate()
    {
        _rigidBody ??= GetComponent<Rigidbody2D>();
    }

    public void ApplyRecoil()
    {
        ResetVelocity();

        Vector2 leftVector = -transform.right * _leftForce;

        float t = Mathf.InverseLerp(_lowerY, _upperY, transform.position.y);
        float dynamicUpForce = Mathf.Lerp(_maxUpForce, _minUpForce, t);
        Vector2 upVector = Vector2.up * dynamicUpForce;

        _rigidBody.AddForce(leftVector + upVector, ForceMode2D.Impulse);
        _rigidBody.AddTorque(_torque, ForceMode2D.Impulse);
    }

    private void ResetVelocity()
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.angularVelocity = 0f;
    }
}