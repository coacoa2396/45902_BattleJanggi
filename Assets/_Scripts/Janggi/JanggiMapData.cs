using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin, Changyu
/// 
/// 말의 위치 상태를 복원하기 위한 클래스
/// </summary>
public class JanggiMapData : MonoBehaviour { }

[Serializable]
public struct PiecePosData
{
    public string pieceName;
    public string whosPiece;

    public int x;
    public int z;

    public bool isPlayer1;
    public bool isPlayer2;

    public int imageNum;

    public string jolWeapon;
}

[Serializable]
public struct PieceData
{
    public PiecePosData[] pieces;

    public void PieceSave(List<Spot> lists)
    {
        pieces = new PiecePosData[lists.Count];
        for (int i = 0; i < lists.Count; i++)
        {
            pieces[i].pieceName = lists[i].WhatPiece.PieceName;
            pieces[i].whosPiece = lists[i].WhosePiece;

            pieces[i].x = lists[i].ThisPos['x'];
            pieces[i].z = lists[i].ThisPos['z'];
            pieces[i].isPlayer1 = lists[i].WhatPiece.IsPlayer1;
            pieces[i].isPlayer2 = lists[i].WhatPiece.IsPlayer2;

            pieces[i].imageNum = lists[i].WhatPiece.ImageNum;

            if (lists[i].WhatPiece.GetComponent<Jol>() != null)
            {
                pieces[i].jolWeapon = lists[i].WhatPiece.GetComponent<Jol>().WeaponCheck;
            }
        }
    }
}
public partial class GameData
{
    public PieceData pieceData;
    public bool isSaved = false;
}
