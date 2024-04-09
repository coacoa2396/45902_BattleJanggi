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
    protected override void Shoot(float chargingPower)
    {
        PooledObject PO = Manager.Pool.GetPool(arrow, transform.position, transform.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
        PO.GetComponent<Arrow>()?.Shoot(transform.forward);
    }
}
