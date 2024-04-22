using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 가시벽 클래스
/// </summary>
public class WallSting : Wall
{
    [SerializeField] LayerMask checkPlayer;
    [SerializeField] float damage;

    // 충돌체크

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
        if (checkPlayer.Contain(collision.gameObject.layer))
        {
            Debug.Log("레이어체크");
            FPSPiece target;
            collision.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(damage);
        }
    }

    // 충돌한 것이 플레이어인 경우 벽의 공격력만큼 플레이어에게 데미지
}
