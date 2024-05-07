using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 제작 : 찬규
/// 한나라와 초나라의 게임패드를 설정하는 컴포넌트
/// </summary>
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
