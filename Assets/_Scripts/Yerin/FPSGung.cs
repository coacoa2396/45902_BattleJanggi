using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(궁) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 궁의 스킬
/// </summary>
public class FPSGung : FPSPiece
{
    [SerializeField] GameObject sword;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(3f);

        CanUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            
        }
    }
}
