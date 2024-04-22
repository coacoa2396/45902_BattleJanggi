using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : Changyu
/// 장기 말 (상)의 벽 형태
/// </summary>
public class WallDecelerate : Wall
{
    // 가속타워랑 같은 원리
    [SerializeField] LayerMask checkPlayer;

    float baseSpeed = 10f;

    // TriggerEnter로 체크하고
    private void OnTriggerEnter(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed -= baseSpeed * 0.05f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed += baseSpeed * 0.05f;
        }
    }
}
