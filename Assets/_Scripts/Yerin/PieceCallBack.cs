using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// FPS 장기말 점프 애니메이션을 위한 클래스
/// 점프 애니메이션 종류 후 isJump를 false로 변경
/// </summary>
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
