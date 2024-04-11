using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPo : FPSPiece
{
    [SerializeField] FPSPoSkill skill;

    public void OnSkill(InputValue value)
    {
        skill.OnSkill(value);
    }
}
