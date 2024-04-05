using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말 사의 스킬
/// </summary>
public class FPSSa : FPSPiece
{
    [SerializeField] GameObject cat;

    Coroutine skill;

    bool canUseSkill = true;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(5f);

        cat.layer = LayerMask.NameToLayer("Default");
        canUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (canUseSkill)
        {
            cat.layer = LayerMask.NameToLayer("Invisible");
            skill = StartCoroutine(Skill());

            canUseSkill = false;
        }
    }

}
