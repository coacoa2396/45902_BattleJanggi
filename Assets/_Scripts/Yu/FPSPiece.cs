using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// ChanGyu, Yerin
/// </summary>
public class FPSPiece : MonoBehaviour
{
    [Header("Spec")]
    [SerializeField] float hp;

    [Header("Componemt")]
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] Rigidbody rigid;

    [Header("Property")]
    [SerializeField] float movePower;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float breakPower;

    [SerializeField] float jumpPower;

    private Vector3 moveDir;

    private void FixedUpdate()
    {
        Move();
    }
     
    /// <summary>
    /// 플레이어 이동 함수
    /// </summary>
    public void Move()
    {
        if (moveDir.x == 0 && rigid.velocity.magnitude < 0.001f)
        {
            rigid.velocity = Vector3.zero;
        }

        // x방향(좌우) 체크
        if (moveDir.x < 0 && rigid.velocity.x > -maxMoveSpeed)      // 왼쪽 이동
        {
            rigid.AddForce(Vector3.right * moveDir.x * movePower);
        }
        else if (moveDir.x > 0 && rigid.velocity.x < maxMoveSpeed)  // 오른쪽 이동
        {
            rigid.AddForce(Vector3.right * moveDir.x * movePower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x > 0.001f)         // 입력이 없을 시 반대로 힘을 줘서 빠르게 멈추게 하여 조작감 개선
        {
            rigid.AddForce(Vector3.left * breakPower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x < -0.001f)        // 입력이 없을 시 반대로 힘을 줘서 빠르게 멈추게 하여 조작감 개선
        {
            rigid.AddForce(Vector3.right * breakPower);
        }

        // z방향(앞뒤) 체크
        if (moveDir.z < 0 && rigid.velocity.z > -maxMoveSpeed)      // 뒤 이동
        {
            rigid.AddForce(Vector3.forward * moveDir.z * movePower);
        }
        else if (moveDir.z > 0 && rigid.velocity.z < maxMoveSpeed)  // 앞 이동
        {
            rigid.AddForce(Vector3.forward * moveDir.z * movePower);
        }
        else if (moveDir.z == 0 && rigid.velocity.z > 0.001f)         // 입력이 없을 시 반대로 힘을 줘서 조작감 개선
        {
            rigid.AddForce(Vector3.back * breakPower);
        }
        else if (moveDir.z == 0 && rigid.velocity.z < -0.001f)        // 입력이 없을 시 반대로 힘을 줘서 조작감 개선
        {
            rigid.AddForce(Vector3.forward * breakPower);
        }

        if (rigid.velocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)  // 최고속도 제한걸기
        {
            rigid.velocity = rigid.velocity.normalized * maxMoveSpeed;
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
        Debug.Log("온점프");
        if (value.isPressed)
            Jump();
    }

    /// <summary>
    /// 점프를 실행하는 함수
    /// </summary>
    void Jump()
    {
        Debug.Log("점프");                
        rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
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
}