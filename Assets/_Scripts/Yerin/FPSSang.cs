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
    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(5f);

        MoveSpeed = MoveSpeed / 1.3f;
        CanUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            MoveSpeed = MoveSpeed * 1.3f;

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
        }
    }
}
