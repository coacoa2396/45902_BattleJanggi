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
    // 차징
    // 누른만큼 날아가는 거리 다르게

    [SerializeField] float normalPower;
    [SerializeField] Bullet arrow;

    float chargingPower;

    Coroutine chargingCoroutine;

    private void Start()
    {
        chargingPower = 0;
    }

    IEnumerator ChargingPower()
    {
        while (true)
        {
            chargingPower += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Shot(float chargingPower)
    {
        Instantiate(arrow, transform.position, transform.rotation);
    }

    public override void Charging()
    {
        chargingCoroutine = StartCoroutine(ChargingPower());
    }

    public override void Fire()
    {
        StopCoroutine(chargingCoroutine);

        Shot(chargingPower);
    }
}
