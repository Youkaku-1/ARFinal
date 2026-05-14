using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneName;

    public void SwitchScene()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is empty. Please write the scene name in the Inspector.");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}