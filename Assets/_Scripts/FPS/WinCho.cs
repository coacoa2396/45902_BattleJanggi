using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCho : MonoBehaviour
{
    public void ChoWin()
    {
        Manager.Scene.GetCurScene<FPSScene>()?.ChoWin();
    }
}
