using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] CinemachineVirtualCamera ZoomCamera;

    CinemachineVirtualCamera curCamera;

    private void Start()
    {
        curCamera = FPSCamera;
    }

    /// <summary>
    /// 우클릭 시에 줌을 해주고 카메라의 시점을 바꾸는 함수
    /// </summary>
    /// <param name="value"></param>
    void OnZoom(InputValue value)
    {
        if (curCamera == FPSCamera)
        {
            curCamera = ZoomCamera;
            ZoomCamera.Priority = 11;
        }
        else
        {
            curCamera = FPSCamera;
            ZoomCamera.Priority = 1;
        }
    }
}
