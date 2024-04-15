using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(마) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 마의 스킬
/// </summary>
public class FPSMa : FPSPiece
{
    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(7f);

        MoveSpeed = MoveSpeed / 1.3f;
        CanUseSkill = true;
    }

    protected override void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            MoveSpeed = MoveSpeed * 1.3f;

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
            base.OnSkill(value);
        }
    }
}
