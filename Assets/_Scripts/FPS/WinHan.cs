using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHan : MonoBehaviour
{
    public void HanWin()
    {
        Manager.Scene.GetCurScene<FPSScene>()?.HanWin();
    }
}
