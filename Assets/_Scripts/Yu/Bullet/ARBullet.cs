using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ¡¶¿€ : ChanGyu
/// æÓΩ‰∆Æ∂Û¿Ã«√ ≈∫»Ø
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] ARImpact explodeEffect;        // ≈∫»Ø¿Ã ¥Íæ“¿ª ∂ß ≥™ø¿¥¬ ¿Ã∆—∆Æ

    private void OnEnable()
    {
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
