using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// 레이저건 피탄시 나오는 이펙트
/// </summary>
public class LazerGunImpact : Impact
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
