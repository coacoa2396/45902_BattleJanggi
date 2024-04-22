using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// 물대포에서 나가는 탄환
/// </summary>
public class WaterCannonBullet : Bullet
{
    [SerializeField] WaterCannonImpact explodeEffect;        // 탄환이 닿았을 때 나오는 이팩트
    float id;

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

    //private void FixedUpdate()
    //{
    //    Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
    //    if (Physics.Linecast(transform.position, nextPos, out RaycastHit hitInfo))
    //    {
    //        FPSPiece target;
    //        hitInfo.collider.gameObject.TryGetComponent<FPSPiece>(out target);

    //        target?.TakeDamage(Damage);

    //        Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(hitInfo.normal));

    //        gameObject.SetActive(false);
    //    }
    //}

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
