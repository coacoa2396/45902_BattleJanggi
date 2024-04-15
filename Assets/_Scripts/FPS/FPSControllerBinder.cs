using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSControllerBinder : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Han"))   // 1P  
        {
            SetGamepad0();
        }
        else
        {
            SetGamepad1();
        }
    }

    [ContextMenu("KeyboardMouse")]
    public void SetKeyboardMouse()
    {
        playerInput.SwitchCurrentControlScheme(Keyboard.current, Mouse.current);
    }

    [ContextMenu("Gamepad0")]
    public void SetGamepad0()
    {
        playerInput.SwitchCurrentControlScheme(Gamepad.all[0]);
    }

    [ContextMenu("Gamepad1")]
    public void SetGamepad1()
    {
        playerInput.SwitchCurrentControlScheme(Gamepad.all[1]);
    }
}
