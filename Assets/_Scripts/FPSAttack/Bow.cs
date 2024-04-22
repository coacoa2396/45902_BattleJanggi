using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 졸이 사용할 활 클래스
/// </summary>
public class Bow : ChargingWeapon
{
    [SerializeField] Bullet arrow;

    float rate = 1.5f;     // 연사속도
    bool isfire;

    protected override void Start()
    {
        base.Start();
        isfire = true;
    }

    protected override void Shoot(float chargingPower)
    {
        if (isfire)
        {
            PooledObject PO = Manager.Pool.GetPool(arrow, transform.position, transform.rotation);
            Bullet initBullet = PO.GetComponent<Bullet>();

            initBullet.Damage = Damage;
            initBullet.Weapon = GetComponent<Weapon>();
            PO.GetComponent<Arrow>()?.Shoot(transform.forward);
            StartCoroutine(CalRate());
        }
    }

    IEnumerator CalRate()
    {
        isfire = false;
        yield return new WaitForSeconds(rate);
        isfire = true;
    }
}
