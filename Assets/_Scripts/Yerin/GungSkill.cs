using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 궁 방어박 스킬
/// </summary>
public class GungSkill : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] FPSPiece enemy;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] FPSGung gung;

    private void Start()
    {
        FPSPiece[] players = FindObjectsOfType<FPSPiece>();        
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == GetComponentInParent<FPSPiece>())
            {
                continue;
            }

            enemy = players[i];
        }
    }

    private void OnEnable()
    {
        gung.CanDamaged = false;
    }

    private void OnDisable()
    {
        gung.CanDamaged = true;
    }

    public void Cast()
    {
        effect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackLayer.Contain(other.gameObject.layer))
        {
            float damage = 0;

            if (other.GetComponent<Bullet>() != null)
            {
                damage = other.GetComponent<Bullet>().Damage;

                other.gameObject.SetActive(false);
            }
            else if (other.GetComponent<PoSkillImpact>() != null)
            {
                damage = other.GetComponent<PoSkillImpact>().Damage;

                Destroy(other.gameObject);
            }
            else if (other.GetComponent<ChaSkillBullet>() != null)
            {
                damage = other.GetComponent<ChaSkillBullet>().Damage;

                Destroy(other.gameObject);
            }

            enemy.TakeDamage(damage);
        }
    }
}
