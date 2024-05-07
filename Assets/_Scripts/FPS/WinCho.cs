using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// FPS씬에서의 초나라의 승리를 판정
/// </summary>
public class WinCho : MonoBehaviour
{
    [ContextMenu("ChoWin")]
    public void ChoWin()
    {
        FPSScene curScene = FindObjectOfType<FPSScene>();

        curScene.ChoWin();
    }
}
