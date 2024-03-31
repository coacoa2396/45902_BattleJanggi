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

    [SerializeField] float jumpPower;

    private Vector3 moveDir;

    private void FixedUpdate()
    {
        Move();
    }

    // 이동
    public void Move()
    {

        rigid.AddForce(moveDir * movePower * Time.fixedDeltaTime, ForceMode.Impulse);      // 인풋액션으로 받아온 평면좌표방향으로 movePower만큼의 힘을 준다

        if (rigid.velocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxMoveSpeed;
        }

        //if (moveDir.x < 0 && rigid.velocity.x > -maxMoveSpeed)
        //{
        //    rigid.AddForce(Vector3.left * movePower * moveDir.x * Time.fixedDeltaTime);
        //}
        //else if (moveDir.x > 0 && rigid.velocity.x < maxMoveSpeed)
        //{
        //    rigid.AddForce(Vector3.left * movePower * moveDir.x * Time.fixedDeltaTime);
        //}

        //if (moveDir.z < 0 && rigid.velocity.z > -maxMoveSpeed)
        //{
        //    rigid.AddForce(Vector3.forward * movePower * moveDir.z * Time.fixedDeltaTime);
        //}
        //else if (moveDir.z > 0 && rigid.velocity.z < maxMoveSpeed)
        //{
        //    rigid.AddForce(Vector3.forward * movePower * moveDir.z * Time.fixedDeltaTime);
        //}
    }
    
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    // 점프
    private void OuJump(InputValue value)
    {

    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp > 0)     // 체력이 0이상이면 리턴
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