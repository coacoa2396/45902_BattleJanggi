using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


/// <summary>
/// ChanGyu, Yerin
/// </summary>
public class FPSPiece : MonoBehaviour
{
    [Header("Spec")]
    [SerializeField] float hp;

    [Header("Componemt")]
    [SerializeField] CharacterController controller;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Weapon weapon;
    [SerializeField] CinemachineVirtualCamera curCamera;
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] CinemachineVirtualCamera ZoomCamera;

    [Header("Property")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float breakPower;
    [SerializeField] float ySpeed;
    
    private Vector3 moveDir;

    private void Start()
    {
        curCamera = FPSCamera;
    }

    private void FixedUpdate()
    {
        Move();
        JumpMove();
    }

    /// <summary>
    /// ChanGyu
    /// 플레이어 이동 함수
    /// </summary>
    public void Move()
    {
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// ChanGyu
    /// 마우스 클릭을 했을 시 발사하는 함수
    /// 차징무기를 위한 로직을 따로 구현한 상태
    /// </summary>
    /// <param name="value"></param>
    void OnFire(InputValue value)
    {
        ChargingWeapon charge;
        if (!weapon.TryGetComponent(out charge))
            charge = null;

        if (value.isPressed)
        {
            if (charge != null)
            {
                charge.Charging();
            }
            else
            {
                weapon.Fire();
            }
        }
        else
        {
            if (charge != null)
            {
                charge.Fire();
            }
        }
    }

    // 인풋액션에서 받아오는 정보
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    // 점프
    private void OnJump(InputValue value)
    {        
        ySpeed = jumpSpeed;
    }

    /// <summary>
    /// 점프를 실행하는 함수
    /// </summary>
    void JumpMove()
    {        
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0f;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);      // 여기서 deltaTime을 한번 더 곱해주니까 제곱이 된다
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp > 0)     // 체력이 0초과면 리턴
            return;

        Die();
    }

    /// <summary>
    /// 사망하는 함수
    /// </summary>
    void Die()
    {

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