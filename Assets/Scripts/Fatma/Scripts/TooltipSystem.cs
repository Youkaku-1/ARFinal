using UnityEngine;
using TMPro;

public class TooltipSystem : MonoBehaviour
{
    public GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;

    public void ShowTooltip(string info)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = info;
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}