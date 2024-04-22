using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Á¦ÀÛÀÚ : ChanGyu
/// Àå±â¸»(Á¹)ÀÌ ½î´Â ±ÇÃÑ¿¡¼­ ³ª°¡´Â ÃÑ¾Ë
/// </summary>
public class PistolBullet : Bullet
{
    [SerializeField] PistolImpact explodeEffect;        // ÅºÈ¯ÀÌ ´ê¾ÒÀ» ¶§ ³ª¿À´Â ÀÌÆÑÆ®

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

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
