using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// FPS카메라의 움직임 관련 클래스
/// </summary>
public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] Transform muzzlePointRoot;

    [SerializeField] float mouseSensitivity;
    [SerializeField] float xRotation;

    Vector2 inputDir;

    private void Update()
    {
        xRotation -= inputDir.y * mouseSensitivity * 2f * Time.deltaTime;           // x축을 기준으로 위아래
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);                              // 회전 각도를 제한한다

        transform.Rotate(Vector3.up, inputDir.x * mouseSensitivity * 2f * Time.deltaTime);      // 좌우는 몸통을 돌려서 보고
        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);                           // 상하는 카메라를 움직여준다
        muzzlePointRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);                      // 탄환이 발사되는 위치도 카메라와 동일하게 움직여준다
        //cameraRoot.Rotate(Vector3.right, -inputDir.y * mouseSensitivity * Time.deltaTime);
    }

    void OnLook(InputValue value)
    {
        inputDir = value.Get<Vector2>();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
