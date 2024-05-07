using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 제작 : 찬규
/// 장기말(차)의 스킬 발동 컴포넌트
/// </summary>
public class FPSCha : FPSPiece
{
    [SerializeField] FPSChaSkill skill;

    protected override void OnSkill(InputValue value)
    {
        skill.OnSkill(value);
        base.OnSkill(value);
    }
}
