using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 차징하는 무기들의 중분류 : 활, 수리검
/// </summary>
public class ChargingWeapon : Weapon
{
    [SerializeField] float normalPower;
    [SerializeField] float chargingSpeed;

    float chargingPower;

    Coroutine chargingCoroutine;

    public float ChargingPower { get { return chargingPower; } set { chargingPower = value; } }
    public Coroutine ChargingCoroutine { get { return chargingCoroutine; } }

    private void Start()
    {
        chargingPower = 0;
    }

    IEnumerator ChargingPowerRoutine()
    {
        while (true)
        {
            chargingPower += chargingSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Charging()
    {
        chargingCoroutine = StartCoroutine(ChargingPowerRoutine());
    }

    public float BowPower()
    {
        return chargingPower + normalPower;
    }

    protected virtual void Shoot(float chargingPower)
    {
    }

    public override void Fire()
    {
        StopCoroutine(ChargingCoroutine);
        Shoot(ChargingPower);
        ChargingPower = 0;
    }
}
