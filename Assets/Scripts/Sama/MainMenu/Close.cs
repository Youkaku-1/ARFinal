using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void CloseGame()
    {
        // If running inside Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a built application
        Application.Quit();
#endif
    }
}