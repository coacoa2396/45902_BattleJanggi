using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] CinemachineVirtualCamera ZoomCamera;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundCheck;

    CinemachineVirtualCamera curCamera;

    [Header("Property")]
    [SerializeField] float moveSpeed;
    [SerializeField] float breakPower;

    bool isGround;  // 플레이어의 땅 위 여부
    bool isWalking; // 플레이어의 걷기 여부
    bool isJumping; // 플레이어의 점프 여부
    
    private Vector3 moveDir;

    private void Start()
    {
        curCamera = FPSCamera;
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ChanGyu
    /// 플레이어 이동 함수
    /// </summary>
    public void Move()
    {
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);

        if (moveDir.x == 0 && moveDir.z == 0)
        {
            isWalking = false;
        }

        if (isGround)
        {
            if (!isJumping)
            {
                if (isWalking)
                {
                    animator.Play("Walk");
                }
                else
                {
                    animator.Play("Idle A");
                }
            }
            else
            {
                animator.Play("Jump");
            }
        }
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

        isWalking = true;
    }

    // 점프
    private void OnJump(InputValue value)
    {       
        isJumping = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (groundCheck.Contain(collision.gameObject.layer))    // 플레이어가 땅 위에 있을 경우
        {
            isGround = true;

            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (groundCheck.Contain(collision.gameObject.layer))    // 플레이어가 땅 위에 없을 경우
        {
            isGround = false;
        }
    }

    public void makeIsJumpingFalse()
    {
        isJumping = false;
    }
}