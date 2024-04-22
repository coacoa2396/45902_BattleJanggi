using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : Changyu
/// 장기 말(마)의 벽 형태.
/// 진입시 플레이어에게 가속을 주는 형식으로 구현
/// </summary>
public class WallAccelerate : Wall
{
    [SerializeField] LayerMask checkPlayer;

    float baseSpeed = 10f;

    // TriggerEnter로 버프체크하고
    private void OnTriggerEnter(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed += baseSpeed * 0.05f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed -= baseSpeed * 0.05f;
        }
    }
}
