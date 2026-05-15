using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    public Renderer carRenderer;

    public void ChangeColor(Color newColor)
    {
        carRenderer.material.color = newColor;
    }
}