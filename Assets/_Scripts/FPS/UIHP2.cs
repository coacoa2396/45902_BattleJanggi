using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHP2 : MonoBehaviour
{
    [SerializeField] Slider hpBar;

    [SerializeField] UIPlayer2 uiplayer2;

    private void LateUpdate()
    {
        float hpPer = uiplayer2.Player2.HP / 100f;
        hpBar.value = hpPer;
    }
}
