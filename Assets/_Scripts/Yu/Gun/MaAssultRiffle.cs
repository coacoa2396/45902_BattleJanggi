using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : Changyu
/// 장기말 (마)의 무기
/// </summary>
public class MaAssultRiffle : Gun
{
    [SerializeField] Transform muzzlePoint;

    public override void Fire()
    {
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
    }
}
