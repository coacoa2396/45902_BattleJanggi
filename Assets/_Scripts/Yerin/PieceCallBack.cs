using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCallBack : MonoBehaviour
{
    FPSPiece player;

    private void Start()
    {
        player = GetComponentInParent<FPSPiece>();
    }

    void CallBack()
    {
        player.makeIsJumpingFalse();
    }
}
