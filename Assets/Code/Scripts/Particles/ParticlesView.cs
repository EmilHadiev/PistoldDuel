using UnityEngine;

public class ParticlesView : MonoBehaviour
{
    public void Play()
    {
        Stop();
        EnableToggle(true);
    }

    public void Stop()
    {
        EnableToggle(false);
    }

    private void EnableToggle(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
}