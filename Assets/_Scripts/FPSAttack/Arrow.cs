using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(포) 벽이 쏘는 화살 관련 클래스
/// </summary>
public class Arrow : Bullet
{
    Coroutine destroy;

    public void Shoot(Vector3 dir)
    {
        Bow bow = Weapon.GetComponent<Bow>();
        Rigid.AddForce(dir * Speed * bow.BowPower());
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
