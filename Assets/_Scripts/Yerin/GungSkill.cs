using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GungSkill : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] FPSPiece enemy;

    private void Start()
    {
        FPSPiece[] players = FindObjectsOfType<FPSPiece>();        
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == GetComponentInParent<FPSPiece>())
                continue;

            enemy = players[i];
        }
    }

    public void Cast()
    {
        effect.Play();
        
    }
}
