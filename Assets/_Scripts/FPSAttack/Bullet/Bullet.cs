using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : ChanGyu
/// 총에서 나가는 탄환의 기본 베이스
/// </summary>
public class Bullet : PooledObject
{
    [Header("Component")]
    [SerializeField] Weapon weapon;
    [SerializeField] Rigidbody rigid;

    [Header("Spec")]
    [SerializeField] float speed;
    float damage;

    public Weapon Weapon { get { return weapon; } set { weapon = value; } }
    public Rigidbody Rigid { get { return rigid; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public float Speed { get { return speed; } set { speed = value; } }

    protected virtual void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(damage);

        gameObject.SetActive(false);
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(5f);
        gameObject?.SetActive(false);
    }
}
