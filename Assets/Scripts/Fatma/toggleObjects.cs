using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectsOnButtonClick : MonoBehaviour
{
    [Header("Button")]
    public Button targetButton;

    [Header("Objects To Disable")]
    public GameObject[] objectsToDisable;

    [Header("Objects To Enable")]
    public GameObject[] objectsToEnable;

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogWarning("Target Button is not assigned!");
        }
    }

    private void OnButtonClicked()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}