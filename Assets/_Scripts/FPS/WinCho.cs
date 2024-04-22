using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCho : MonoBehaviour
{
    [ContextMenu("ChoWin")]
    public void ChoWin()
    {
        FPSScene curScene = FindObjectOfType<FPSScene>();

        curScene.ChoWin();
    }
}
