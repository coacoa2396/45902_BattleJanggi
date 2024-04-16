using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiWinnerCho : MonoBehaviour
{
    [ContextMenu("ChoWin")]
    public void ChoWin()
    {
        JanggiScene curScene = FindObjectOfType<JanggiScene>();

        curScene.ChoWin();
    }
}
