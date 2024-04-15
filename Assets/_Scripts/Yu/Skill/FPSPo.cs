using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPo : FPSPiece
{
    [SerializeField] FPSPoSkill skill;

    protected override void OnSkill(InputValue value)
    {
        skill.OnSkill(value);
        base.OnSkill(value);
    }
}
