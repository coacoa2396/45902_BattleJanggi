using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// 제작 : ChanGyu
/// CinemachineVirtualCamera의 FOV를 이용한 줌 기능 구현
/// </summary>
public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] Image normalScope;
    [SerializeField] Image zoomScope;

    [SerializeField] float normalFOV = 60;
    [SerializeField] float zoomFOV = 20;
    [SerializeField] float lerpFOV;
    [SerializeField] float zoomSpeed;

    State curState;

    bool zooming;

    private void Start()
    {
        curState = State.NormalCam;
        zooming = false;
    }

    /// <summary>
    /// 우클릭 시에 줌을 해주고 카메라의 시점을 바꾸는 함수
    /// </summary>
    /// <param name="value"></param>
    void OnZoom(InputValue value)
    {
        if (!zooming)
        {
            if (curState == State.NormalCam)
            {
                zooming = true;
                curState = State.ZoomCam;
                StartCoroutine(NorToZoom());
                normalScope.gameObject.SetActive(false);
                zoomScope.gameObject.SetActive(true);
            }
            else
            {
                zooming = true;
                curState = State.NormalCam;
                StartCoroutine(ZoomToNor());
                normalScope.gameObject.SetActive(true);
                zoomScope.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator NorToZoom()
    {
        lerpFOV = normalFOV;
        while (true)
        {
            lerpFOV = Mathf.Lerp(lerpFOV, zoomFOV, zoomSpeed * Time.fixedDeltaTime);
            FPSCamera.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = lerpFOV;

            if (Mathf.Abs(lerpFOV - zoomFOV) < 0.1f)
            {
                FPSCamera.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = zoomFOV;
                zooming = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator ZoomToNor()
    {
        lerpFOV = zoomFOV;
        while (true)
        {
            lerpFOV = Mathf.Lerp(lerpFOV, normalFOV, zoomSpeed * Time.fixedDeltaTime);
            FPSCamera.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = lerpFOV;

            if (Mathf.Abs(lerpFOV - normalFOV) < 0.1f)
            {
                FPSCamera.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = normalFOV;
                zooming = false;
                break;
            }
            yield return null;
        }
    }

    enum State { NormalCam, ZoomCam }
}
