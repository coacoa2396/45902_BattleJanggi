using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 화살 관련 클래스
/// </summary>
public class Arrow : Bullet
{
    public void Shoot(Vector3 dir)
    {
        Bow bow = Weapon.GetComponent<Bow>();
        Rigid.AddForce(dir * Speed * bow.BowPower());
    }
}
