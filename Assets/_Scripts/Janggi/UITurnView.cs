using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITurnView : MonoBehaviour
{
    [SerializeField] TMP_Text text;    

    private void LateUpdate()
    {
        text.text = Manager.JanggiTurn.Turn.ToString();
    }
}
