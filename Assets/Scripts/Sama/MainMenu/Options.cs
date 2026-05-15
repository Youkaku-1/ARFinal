using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [Header("Objects To Disable")]
    [SerializeField] private GameObject[] objectsToDisable;

    [Header("Objects To Enable")]
    [SerializeField] private GameObject[] objectsToEnable;

    public void ToggleObjects()
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