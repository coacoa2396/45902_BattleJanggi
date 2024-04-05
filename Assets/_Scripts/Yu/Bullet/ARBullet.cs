using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ¡¶¿€ : ChanGyu
/// æÓΩ‰∆Æ∂Û¿Ã«√ ≈∫»Ø
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] 

    private void OnEnable()
    {
        Rigid.velocity = transform.forward * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
