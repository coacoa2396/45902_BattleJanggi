using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 제작자 : Changyu
/// 장기말 (마)의 무기
/// </summary>
public class MaAssultRiffle : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;

    float rate = 0.2f;     // 연사속도
    bool isfire;

    Coroutine coroutine;

    protected override void Start()
    {
        base.Start();
        isfire = true;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    public override void Fire()
    {
        if (!isfire)
            return;

        muzzleFlash.Play();
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
    }

    IEnumerator Firing()
    {
        while (true)
        {
            if (curMagazine > 0)
            {
                Fire();
                curMagazine--;
                yield return new WaitForSeconds(rate);
            }
            else
            {
                StartCoroutine(Reload());
                break;
            }
        }
    }

    public void StartFiring()
    {
        coroutine = StartCoroutine(Firing());
    }

    public void StopFiring()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    IEnumerator Reload()
    {
        isfire = false;
        yield return new WaitForSeconds(1f);
        isfire = true;
        curMagazine = maxMagazine;
    }
}
