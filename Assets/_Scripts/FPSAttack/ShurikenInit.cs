using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 사가 사용할 수리검 클래스
/// </summary>
public class ShurikenInit : ChargingWeapon
{
    [SerializeField] Bullet shuriken;

    float rate = 1f;     // 연사속도
    bool isfire;

    protected override void Start()
    {
        base.Start();
        isfire = true;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    protected override void Shoot(float chargingPower)
    {
        if (curMagazine > 0)
        {
            if (!isfire)
                return;

            PooledObject PO = Manager.Pool.GetPool(shuriken, transform.position, transform.rotation);
            Bullet initBullet = PO.GetComponent<Bullet>();

            curMagazine--;

            initBullet.Damage = Damage;
            initBullet.Weapon = GetComponent<Weapon>();
            PO.GetComponent<Shuriken>()?.Shoot(transform.forward);
            StartCoroutine(CalRate());
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator CalRate()
    {
        isfire = false;
        yield return new WaitForSeconds(rate);
        isfire = true;
    }

    IEnumerator Reload()
    {
        isfire = false;
        yield return new WaitForSeconds(1f);
        isfire = true;
        curMagazine = maxMagazine;
    }
}
