using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHan : MonoBehaviour
{
    [ContextMenu("HanWin")]
    public void HanWin()
    {
        FPSScene curScene = FindObjectOfType<FPSScene>();

        curScene.HanWin();
    }
}
