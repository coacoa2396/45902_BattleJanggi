using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 차징하는 무기들의 중분류 : 활, 수리검
/// </summary>
public class ChargingWeapon : Weapon
{
    /// <summary>
    /// 차징 가상 함수
    /// </summary>
    public virtual void Charging() { }
}
