using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 장기말(차)의 레일건에서 나가는 탄환
/// </summary>
public class ChaSkillBullet : MonoBehaviour
{
    [SerializeField] LayerMask railGunCheck;            // 플레이어와 벽 체크

    [SerializeField] Rigidbody rigid;

    [SerializeField] float damage;
    [SerializeField] float speed;

    public float Damage {  get { return damage; } }

    private void Start()
    {
        damage = 10;
        speed = 150;
        StartCoroutine(AttackFlow());
        rigid.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        RaycastHit[] hits;
        Vector3 nextPos = transform.position + rigid.velocity * Time.fixedDeltaTime;
        hits = Physics.RaycastAll(transform.position, nextPos);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (railGunCheck.Contain(hits[i].transform.gameObject.layer))
                {
                    FPSPiece player = hits[i].transform.gameObject.GetComponent<FPSPiece>();
                    player?.TakeDamage(damage);
                    Wall wall = hits[i].transform.gameObject.GetComponent<Wall>();
                    wall?.DestroySelf();
                }
            }
        }
    }

    IEnumerator AttackFlow()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}


