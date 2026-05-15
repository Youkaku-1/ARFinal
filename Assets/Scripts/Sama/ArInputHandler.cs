using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArInputHandler : MonoBehaviour
{
   public event Action<Vector2> OnPerformTap;

   [SerializeField] private InputActionReference tapAction;

   private void OnEnable()
    {
        tapAction.action.started += OnTriggered;
        tapAction.action.Enable();
    }

    private void OnDisable()
    {
        tapAction.action.started -= OnTriggered;
        tapAction.action.Disable();
    }

    private void OnTriggered(InputAction.CallbackContext context)
    {
        if (Pointer.current !=null)
        {
            Vector2 screenPosition = Pointer.current.position.ReadValue();
            OnPerformTap?.Invoke(screenPosition);
        }
    }
}