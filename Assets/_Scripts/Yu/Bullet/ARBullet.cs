using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : ChanGyu
/// 어썰트라이플 탄환
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] ARImpact explodeEffect;        // 탄환이 닿았을 때 나오는 이팩트
    /// <summary>
    /// 탄환이 풀링됐을 시 탄환의 앞으로 속도를 가해준다
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }
    /// <summary>
    /// 탄환의 피격판정
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
        if (Physics.Linecast(transform.position, nextPos, out RaycastHit hitInfo))
        {
            FPSPiece target;
            hitInfo.collider.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(Damage);

            Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(hitInfo.normal));

            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
