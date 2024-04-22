using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJanggi : MonoBehaviour
{
    private void Start()
    {
        if (Manager.JanggiTurn.CurrentTurn != null)
        {
            Manager.JanggiCamera.FindCamare();
            Manager.JanggiTurn.TimerSet();
            Manager.KillListManager.gameObject.SetActive(true);
        }
    }
}
