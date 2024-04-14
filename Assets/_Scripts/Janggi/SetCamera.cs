using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    private void Start()
    {
        if (Manager.JanggiTurn.CurrentTurn != null)
        {
            Manager.JanggiCamera.FindCamare();
        }
    }
}
