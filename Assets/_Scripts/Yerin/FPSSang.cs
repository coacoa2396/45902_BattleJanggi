using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(상) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 상의 스킬
/// </summary>
public class FPSSang : FPSPiece
{
    [SerializeField] Bullet waterBalloon;
    [SerializeField] GameObject muzzlePoint;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(5f);

        CanUseSkill = true;
        muzzlePoint.SetActive(false);
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            WaterBalloon();

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(60f);
        }
    }

    private void WaterBalloon()
    {
        muzzlePoint.SetActive(true);

        PooledObject PO = Manager.Pool.GetPool(waterBalloon, muzzlePoint.transform.position, muzzlePoint.transform.rotation);

        PO.GetComponent<WaterBalloon>()?.Shoot(muzzlePoint.transform.forward);
    }
}
