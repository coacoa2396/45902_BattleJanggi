using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;

    [SerializeField] float mouseSensitivity;
    [SerializeField] float xRotation;

    Vector2 inputDir;

    private void Update()
    {
        xRotation -= inputDir.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.Rotate(Vector3.up, inputDir.x * mouseSensitivity * Time.deltaTime);
        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);
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
