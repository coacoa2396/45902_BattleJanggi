using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말 포의 벽
/// 공격 범위 설정을 위한 함수
/// </summary>
public class PoAttackRange : MonoBehaviour
{
    [SerializeField] LayerMask playerCheck;

    bool isInTrigger;

    public bool IsInTrigger { get { return isInTrigger; } }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            isInTrigger = false;
        }
    }
}
