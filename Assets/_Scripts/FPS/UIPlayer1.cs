using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 플레이어1과 플레이어1의 UI를 연결한다
/// </summary>
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
