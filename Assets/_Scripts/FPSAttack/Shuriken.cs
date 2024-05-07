using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말 사 수리검 관련 클래스
/// 수리검 발사 관련
/// </summary>
public class Shuriken : Bullet
{
    Coroutine destroy;

    public void Shoot(Vector3 dir)
    {
        ShurikenInit shuri = Weapon.GetComponent<ShurikenInit>();
        Rigid.AddForce(dir * Speed * shuri.BowPower());
    }

    IEnumerator arrowDestroy()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
