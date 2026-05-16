using UnityEngine;

public class EngineSystem : MonoBehaviour
{
    public AudioSource engineSound;

    public void PlayEngine()
    {
        if (!engineSound.isPlaying)
            engineSound.Play();
    }

    public void StopEngine()
    {
        engineSound.Stop();
    }
}
