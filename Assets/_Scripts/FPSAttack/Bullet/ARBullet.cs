using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 제작 : ChanGyu
/// 어썰트라이플 탄환
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] ARImpact explodeEffect;        // 탄환이 닿았을 때 나오는 이팩트
    [SerializeField] LayerMask playerCheck;         // 플레이어 체크하는 레이어마스크

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
        RaycastHit[] hits;

        Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
        hits = Physics.RaycastAll(transform.position, transform.forward, Vector3.Distance(transform.position, nextPos));

        foreach (RaycastHit hit in hits)
        {
            if (playerCheck.Contain(hit.transform.gameObject.layer))
            {
                FPSPiece target;
                hit.collider.gameObject.TryGetComponent<FPSPiece>(out target);

                target?.TakeDamage(Damage);

                Manager.Pool.GetPool(explodeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                gameObject.SetActive(false);
                return;
            }

            Collider[] colls = hit.transform.gameObject.GetComponents<Collider>();

            foreach (Collider coll in colls)
            {
                if (coll.isTrigger)
                {
                    break;
                }
                else
                {
                    Manager.Pool.GetPool(explodeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                    gameObject.SetActive(false);

                    return;
                }
            }
        }
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
