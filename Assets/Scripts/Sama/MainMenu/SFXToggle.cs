using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableScript : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button button;

    [Header("Script To Disable")]
    [SerializeField] private MonoBehaviour scriptToDisable;

    private void Start()
    {
        if (button == null)
        {
            Debug.LogError("Button is missing. Please assign the Button in the Inspector.");
            return;
        }

        if (scriptToDisable == null)
        {
            Debug.LogError("Script To Disable is missing. Please assign the script in the Inspector.");
            return;
        }

        // Subscribe to the button OnClick event
        button.onClick.AddListener(DisableScript);
    }

    private void DisableScript()
    {
        scriptToDisable.enabled = false;
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            // Unsubscribe from the button OnClick event
            button.onClick.RemoveListener(DisableScript);
        }
    }
}