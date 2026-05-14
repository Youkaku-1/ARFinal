using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonToggleSwitchLoop : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button button;

    [Header("First List")]
    [SerializeField] private List<GameObject> firstObjects = new List<GameObject>();

    [Header("Second List")]
    [SerializeField] private List<GameObject> secondObjects = new List<GameObject>();

    private bool isFirstListActive = true;

    private void Start()
    {
        if (button == null)
        {
            Debug.LogError("Button is missing. Please assign the Button in the Inspector.");
            return;
        }

        // Subscribe to the button OnClick event
        button.onClick.AddListener(ToggleObjects);
    }

    private void ToggleObjects()
    {
        if (isFirstListActive)
        {
            // Turn OFF first list
            SetObjectsActive(firstObjects, false);

            // Turn ON second list
            SetObjectsActive(secondObjects, true);
        }
        else
        {
            // Turn ON first list
            SetObjectsActive(firstObjects, true);

            // Turn OFF second list
            SetObjectsActive(secondObjects, false);
        }

        // Switch state for next click
        isFirstListActive = !isFirstListActive;
    }

    private void SetObjectsActive(List<GameObject> objectsList, bool state)
    {
        // This handles empty lists safely
        if (objectsList == null || objectsList.Count == 0)
        {
            return;
        }

        foreach (GameObject obj in objectsList)
        {
            if (obj != null)
            {
                obj.SetActive(state);
            }
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            // Unsubscribe from the button OnClick event
            button.onClick.RemoveListener(ToggleObjects);
        }
    }
}