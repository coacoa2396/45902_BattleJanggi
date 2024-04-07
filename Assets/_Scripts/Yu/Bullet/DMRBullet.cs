using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// DMR에서 나오는 탄환
/// </summary>
public class DMRBullet : Bullet
{
    [SerializeField] DMRImpact explodeEffect;        // 탄환이 닿았을 때 나오는 이팩트

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(Damage);
        Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
