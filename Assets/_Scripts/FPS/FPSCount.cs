using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCount : MonoBehaviour
{
    private void Start()
    {
        Manager.JanggiTurn.StopTurnCount();
    }
}
