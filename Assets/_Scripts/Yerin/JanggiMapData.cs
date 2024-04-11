using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiMapData : MonoBehaviour {}

[Serializable]
public struct PiecePosData
{
    public string pieceName;
    public string whosPiece;
    public int x;
    public int z;
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
        }
    }
}

public partial class GameData
{
    public PieceData pieceData;
}
