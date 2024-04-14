using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void LateUpdate()
    {
        text.text = ((int)(Manager.JanggiTurn.Timer)).ToString();
    }
}
