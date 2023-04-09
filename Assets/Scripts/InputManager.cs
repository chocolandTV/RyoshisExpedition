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
            PlayerController.Instance.PlayerDirectionX = context.ReadValue<Vector2>().x;
            PlayerController.Instance.PlayerDirectionY = context.ReadValue<Vector2>().y;
        }
        if(context.canceled)
        {
            PlayerController.Instance.PlayerDirectionX = 0f;
            PlayerController.Instance.PlayerDirectionY = 0f;
        }
    }
    public void OnBlockChange(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            BlockSpawnController.Instance.SpawnNewBlock();
            
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
