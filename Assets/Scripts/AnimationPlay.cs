using UnityEngine;
using UnityEngine.UI;

public class ToggleSpawnedCarAnimatorTriggers : MonoBehaviour
{
    public Button button;

    [Header("Spawned Car Settings")]
    public string spawnedCarTag = "Car";

    [Header("Animator Trigger Names")]
    public string firstTriggerName = "Open";
    public string secondTriggerName = "Close";

    private Animator targetAnimator;
    private bool useFirstTrigger = true;

    private void Start()
    {
        if (button != null)
            button.onClick.AddListener(ToggleTrigger);
    }

    private void ToggleTrigger()
    {
        FindSpawnedCarAnimator();

        if (targetAnimator == null)
        {
            Debug.LogWarning("No spawned car Animator found.");
            return;
        }

        if (useFirstTrigger)
            targetAnimator.SetTrigger(firstTriggerName);
        else
            targetAnimator.SetTrigger(secondTriggerName);

        useFirstTrigger = !useFirstTrigger;
    }

    private void FindSpawnedCarAnimator()
    {
        GameObject spawnedCar = GameObject.FindGameObjectWithTag(spawnedCarTag);

        if (spawnedCar == null)
        {
            targetAnimator = null;
            return;
        }

        targetAnimator = spawnedCar.GetComponentInChildren<Animator>();
    }
}