using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 장기말 (상)의 물대포
/// </summary>
public class SangWaterCannon : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] float rate;        // 발사간격

    bool checkFirable;
    bool isReloading;

    protected override void Start()
    {
        checkFirable = true;        
    }

    public override void Fire()
    {
        if (!checkFirable)
            return;

        muzzleFlash.Play();
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
        StartCoroutine(FireChecker());
    }

    IEnumerator FireChecker()
    {
        checkFirable = false;
        yield return new WaitForSeconds(rate);
        checkFirable = true;
    }
}
