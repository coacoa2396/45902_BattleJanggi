using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// FPS씬에서의 한나라의 승리를 판정
/// </summary>
public class WinHan : MonoBehaviour
{
    [ContextMenu("HanWin")]
    public void HanWin()
    {
        FPSScene curScene = FindObjectOfType<FPSScene>();

        curScene.HanWin();
    }
}
