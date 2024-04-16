using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiWinnerHan : MonoBehaviour
{
    [ContextMenu("HanWin")]
    public void HanWin()
    {
        JanggiScene curScene = FindObjectOfType<JanggiScene>();

        curScene.HanWin();
    }
}
