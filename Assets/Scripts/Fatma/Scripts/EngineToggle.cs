using UnityEngine;
using TMPro;

public class EngineToggle : MonoBehaviour
{
    public AudioSource engineSource;

    public AudioClip normalEngine;
    public AudioClip sportEngine;

    public TextMeshProUGUI modeText;

    private bool sportMode = false;

    public void ToggleEngine()
    {
        sportMode = !sportMode;

        if (sportMode)
        {
            engineSource.clip = sportEngine;
            modeText.text = "Sport Mode";
        }
        else
        {
            engineSource.clip = normalEngine;
            modeText.text = "Normal Mode";
        }

        engineSource.Play();
    }
}