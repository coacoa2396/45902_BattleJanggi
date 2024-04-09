using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기씬 카메라 전환 관리 클래스
/// </summary>
public class JanggiCamera : Singleton<JanggiCamera>
{
    [SerializeField] CinemachineVirtualCamera hanLowCam;
    [SerializeField] CinemachineVirtualCamera hanChooseCam;
    [SerializeField] CinemachineVirtualCamera choLowCam;
    [SerializeField] CinemachineVirtualCamera choChooseCam;

    CinemachineVirtualCamera currentCam;

    private void Start()
    {
        currentCam = hanLowCam;
    }

    /// <summary>
    /// 카메라 무빙을 하이로 올리는 작업
    /// </summary>
    public void CameraMoveHigh()
    {
        if (Manager.JanggiTurn.CurrentTurn.Equals("Han"))   // 한나라의 HighCam으로 이동해야 할 떄
        {
            hanChooseCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = hanChooseCam;
        }
        else if (Manager.JanggiTurn.CurrentTurn.Equals("Cho"))  // 초나라의 HighCam으로 이동해야 할 떄
        {
            choChooseCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = choChooseCam;
        }
    }

    /// <summary>
    /// 카메라 무빙을 로우로 내리는 작업
    /// </summary>
    public void CameraMoveLow()
    {
        if (Manager.JanggiTurn.CurrentTurn.Equals("Han"))   // 한나라의 LowCam으로 이동해야 할 떄
        {
            hanLowCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = hanLowCam;
        }
        else if (Manager.JanggiTurn.CurrentTurn.Equals("Cho"))  // 초나라의 LowCam으로 이동해야 할 떄
        {
            choLowCam.Priority = 20;
            currentCam.Priority= 10;

            currentCam = choLowCam;
        }
    }
}
