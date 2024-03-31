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
    [Header("Componemt")]
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] new Rigidbody rigid;

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
        if (moveDir.x < 0 && rigid.velocity.x > -maxMoveSpeed)
        {
            rigid.AddForce(Vector3.left * movePower * moveDir.x);
        }
        else if (moveDir.x > 0 && rigid.velocity.x < maxMoveSpeed)
        {
            rigid.AddForce(Vector3.left * movePower * moveDir.x);
        }

        if (moveDir.z < 0 && rigid.velocity.z > -maxMoveSpeed)
        {
            rigid.AddForce(Vector3.forward * movePower * moveDir.x);
        }
        else if (moveDir.z > 0 && rigid.velocity.z < maxMoveSpeed)
        {
            rigid.AddForce(Vector3.forward * movePower * moveDir.x);
        }
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
}