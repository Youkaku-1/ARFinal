using UnityEngine;
using UnityEngine.UI;

public class ToggleTwoAnimatorTriggersOnClick : MonoBehaviour
{
    public Button button;
    public Animator targetAnimator;

    [Header("Animator Trigger Names")]
    public string firstTriggerName = "Open";
    public string secondTriggerName = "Close";

    private bool useFirstTrigger = true;

    private void Start()
    {
        Debug.Log("ToggleTwoAnimatorTriggersOnClick: Start() called");
        if (button != null)
        {
            Debug.Log("ToggleTwoAnimatorTriggersOnClick: Button assigned, adding listener");
            button.onClick.AddListener(ToggleTrigger);
        }
        else
        {
            Debug.LogWarning("ToggleTwoAnimatorTriggersOnClick: Button is NOT assigned!");
        }
    }

    private void ToggleTrigger()
    {
        Debug.Log("ToggleTwoAnimatorTriggersOnClick: ToggleTrigger() called");
        
        if (targetAnimator == null)
        {
            Debug.LogWarning("ToggleTwoAnimatorTriggersOnClick: Target Animator is not assigned.");
            return;
        }

        Debug.Log("ToggleTwoAnimatorTriggersOnClick: useFirstTrigger = " + useFirstTrigger);
        
        if (useFirstTrigger)
        {
            Debug.Log("ToggleTwoAnimatorTriggersOnClick: Setting trigger '" + firstTriggerName + "'");
            targetAnimator.SetTrigger(firstTriggerName);
        }
        else
        {
            Debug.Log("ToggleTwoAnimatorTriggersOnClick: Setting trigger '" + secondTriggerName + "'");
            targetAnimator.SetTrigger(secondTriggerName);
        }

        useFirstTrigger = !useFirstTrigger;
        Debug.Log("ToggleTwoAnimatorTriggersOnClick: Toggled. useFirstTrigger is now = " + useFirstTrigger);
    }
}