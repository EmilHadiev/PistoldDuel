using UnityEngine;

public class GunSound : MonoBehaviour, IGunSound
{
    private ISoundContainer _soundContainer;

    public void Init(ISoundContainer soundContainer)
    {
        _soundContainer = soundContainer;
    }

    public void Play(string soundName)
    {
        if (_soundContainer == null)
        {
            Debug.LogError("Sound container is null you need to init");
            return;
        }

        _soundContainer.Play(soundName);
    }
}