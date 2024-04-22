using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer2 : MonoBehaviour
{
    [SerializeField] public FPSPiece Player2;
    [SerializeField] LayerMask choCheck;

    private void Start()
    {
        FPSPiece[] players = FindObjectsOfType<FPSPiece>();

        for (int i = 0; i < players.Length; i++)
        {
            if (choCheck.Contain(players[i].gameObject.layer))
            {
                Player2 = players[i];
            }
        }
    }
}
