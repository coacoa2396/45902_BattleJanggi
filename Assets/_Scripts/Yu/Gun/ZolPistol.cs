using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 제작자 : ChanGyu
/// 장기말 (졸)의 기본무기
/// </summary>
public class ZolPistol : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;

    float rate = 0.75f;     // 연사속도
    bool isfire;
    bool isReloading;

    protected override void Start()
    {
        base.Start();
        isfire = true;
        isReloading = false;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    public override void Fire()
    {
        if (curMagazine > 0)
        {
            if (isfire)
            {
                muzzleFlash.Play();
                PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
                Bullet initBullet = PO.GetComponent<Bullet>();

                curMagazine--;

                initBullet.Damage = Damage;
                initBullet.Weapon = GetComponent<Weapon>();
                StartCoroutine(CalRate());
            }
        }
        else
        {
            isReloading = true;

            if (isReloading)
                return;

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
        isReloading = false;
        curMagazine = maxMagazine;
    }
}
