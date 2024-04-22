using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 플레이어2와 플레이어2의 UI를 연결한다
/// </summary>
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
