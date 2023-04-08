using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnDirection(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerController.Instance.PlayerDirection = context.ReadValue<Vector2>();
        }
        if(context.canceled)
        {
            PlayerController.Instance.PlayerDirection = Vector2.zero;
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameManager.Instance.OnPause();
        }
    }
    public void OnRotate(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerController.Instance.Rotate();
        }
    }
}
