using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 화살 관련 클래스
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

    private void OnEnable()
    {
        destroy = StartCoroutine(arrowDestroy());
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
