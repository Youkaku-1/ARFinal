using UnityEngine;

public class WheelSwitcher : MonoBehaviour
{
    public GameObject[] wheelSets;

    public void SelectWheel(int index)
    {
        for (int i = 0; i < wheelSets.Length; i++)
        {
            wheelSets[i].SetActive(i == index);
        }
    }
}