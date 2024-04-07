using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// 물대포 피탄 시 나오는 이팩트
/// </summary>
public class WaterCannonImpact : Impact
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
