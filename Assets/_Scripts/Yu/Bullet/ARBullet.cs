using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : ChanGyu
/// 어썰트라이플 탄환
/// </summary>
public class ARBullet : Bullet
{
    private void Start()
    {
        Speed = 30f;
    }

    private void OnEnable()
    {
        Rigid.AddForce(Vector3.forward * Speed);
    }
}
