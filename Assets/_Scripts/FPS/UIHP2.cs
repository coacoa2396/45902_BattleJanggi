using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// 플레이어2의 체력바
/// </summary>
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
