using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiLoadManager : MonoBehaviour
{
    [SerializeField] JanggiLogic janggiLogic;

    public void FPStoJanggi()
    {
        Manager.Data.LoadData(1);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {

        }
    }
}
