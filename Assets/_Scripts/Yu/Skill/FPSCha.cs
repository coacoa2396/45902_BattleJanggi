using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCha : FPSPiece
{
    [SerializeField] FPSChaSkill skill;

    public void OnSkill(InputValue value)
    {
        skill.OnSkill(value);
    }
}
