using UnityEngine;
using UnityEngine.UI;

public class PlayAnimationBoolOnButtonClick : MonoBehaviour
{
    [Header("Button")]
    public Button targetButton;

    [Header("Animator Object")]
    public Animator targetAnimator;

    [Header("Bool Parameter Name")]
    public string boolName = "Play";

    [Header("Bool Value When Button Is Clicked")]
    public bool valueOnClick = true;

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(PlayAnimation);
        }
        else
        {
            Debug.LogWarning("Target Button is not assigned!");
        }
    }

    private void PlayAnimation()
    {
        if (targetAnimator != null)
        {
            targetAnimator.SetBool(boolName, valueOnClick);
        }
        else
        {
            Debug.LogWarning("Target Animator is not assigned!");
        }
    }
}