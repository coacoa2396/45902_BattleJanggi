using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer1 : MonoBehaviour
{
    [SerializeField] public FPSPiece Player1;
    [SerializeField] LayerMask hanCheck;

    private void Start()
    {
        FPSPiece[] players = FindObjectsOfType<FPSPiece>();

        for (int i = 0; i < players.Length; i++)
        {
            if (hanCheck.Contain(players[i].gameObject.layer))
            {
                Player1 = players[i];
            }
        }
    }
}
