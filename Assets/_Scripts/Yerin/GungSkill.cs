using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GungSkill : MonoBehaviour
{
    [SerializeField] LayerMask haveDamage;
    [SerializeField] ParticleSystem effect;

    List<FPSPiece> players;

    private void Start()
    {
        FPSPiece[] findPlayers = GetComponents<FPSPiece>();

        foreach (FPSPiece p in findPlayers)
        {
            players.Add(p);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (haveDamage.Contain(other.gameObject.layer))
        {
            other.gameObject.SetActive(false); // °í¹Î ÇÊ¿ä

            foreach (FPSPiece p in players) 
            {
                if (p != gameObject)
                {
                    p.TakeDamage(p.Weapon.Damage);
                }
            }
        }
    }
}
