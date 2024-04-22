using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiCount : MonoBehaviour
{
    private void Start()
    {
        if (Manager.JanggiTurn.Turn != 1)
        {
            Debug.Log("In");
            Manager.JanggiLoadManager.LoadStart();
        }

        if (Manager.JanggiLogic.IsSet && Manager.JanggiTurn.Turn == 1)
        {
            Manager.JanggiLoadManager.LoadStart();
            Manager.JanggiLogic.IsSet = false;
        }

        Manager.JanggiTurn.StartTurnCount();
    }
}
