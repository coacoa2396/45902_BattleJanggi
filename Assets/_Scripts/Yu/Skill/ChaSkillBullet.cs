using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaSkillBullet : MonoBehaviour
{
    [SerializeField] LayerMask railGunCheck;            // 플레이어와 벽 체크

    [SerializeField] Rigidbody rigid;

    [SerializeField] float damage;
    [SerializeField] float speed;

    private void Start()
    {
        damage = 10;
        speed = 150;
        StartCoroutine(AttackFlow());
        rigid.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (railGunCheck.Contain(other.gameObject.layer))
        {
            FPSPiece player = other.gameObject.GetComponent<FPSPiece>();
            player?.TakeDamage(damage);
            Wall wall = other.gameObject.GetComponent<Wall>();
            wall?.DestroySelf();
        }
    }

    IEnumerator AttackFlow()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
