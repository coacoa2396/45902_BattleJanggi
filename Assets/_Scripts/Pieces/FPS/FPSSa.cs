using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(사) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 사의 스킬
/// </summary>
public class FPSSa : FPSPiece
{
    [SerializeField] GameObject cat;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(3f);

        cat.layer = LayerMask.NameToLayer("Player");
        CanUseSkill = true;
    }

    protected override void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            cat.layer = LayerMask.NameToLayer("Invisible");
            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
            base.OnSkill(value);
        }
    }
}
