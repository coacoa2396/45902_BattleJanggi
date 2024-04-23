using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// 장기말(졸)이 쏘는 권총에서 나가는 총알
/// </summary>
public class PistolBullet : Bullet
{
    [SerializeField] PistolImpact explodeEffect;        // 탄환이 닿았을 때 나오는 이팩트
    [SerializeField] LayerMask playerCheck;         // 플레이어 체크하는 레이어마스크

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

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

        /*Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
        if (Physics.Linecast(transform.position, nextPos, out RaycastHit hitInfo))
        {
            FPSPiece target;
            hitInfo.collider.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(Damage);

            Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(hitInfo.normal));

            gameObject.SetActive(false);
        }*/
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
