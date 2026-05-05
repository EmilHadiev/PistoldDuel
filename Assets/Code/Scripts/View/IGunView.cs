using UnityEngine;

public interface IGunView
{
    void PlayAttackAnimation();
    void PlayDieAnimation();

    void SetColor(Color color);
}