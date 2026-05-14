using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonListAudioSubscriber : MonoBehaviour
{
    [Header("Buttons List")]
    [SerializeField] private List<Button> buttons = new List<Button>();

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(PlayAudio);
            }
        }
    }

    private void PlayAudio()
    {
        if (audioSource == null)
        {
            Debug.LogError("Audio Source is missing. Please assign it in the Inspector.");
            return;
        }

        if (audioClip == null)
        {
            Debug.LogError("Audio Clip is missing. Please assign it in the Inspector.");
            return;
        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.RemoveListener(PlayAudio);
            }
        }
    }
}