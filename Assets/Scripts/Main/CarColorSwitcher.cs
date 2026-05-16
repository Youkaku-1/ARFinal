using UnityEngine;
using UnityEngine.UI;

public class ChangeDraggedMaterialColorOnClick : MonoBehaviour
{
    public Button button;

    [Header("Drag the material here")]
    public Material targetMaterial;

    [Header("Hex Color")]
    public string hexColor = "#FF0000";

    private void Start()
    {
        if (button != null)
            button.onClick.AddListener(ChangeColor);
    }

    private void ChangeColor()
    {
        if (targetMaterial == null)
        {
            Debug.LogWarning("Target Material is not assigned.");
            return;
        }

        if (ColorUtility.TryParseHtmlString(hexColor, out Color newColor))
        {
            targetMaterial.color = newColor;
        }
        else
        {
            Debug.LogWarning("Invalid hex color: " + hexColor);
        }
    }
}