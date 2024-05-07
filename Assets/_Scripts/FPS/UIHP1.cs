using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// 플레이어1의 체력바
/// </summary>
public class UIHP1 : MonoBehaviour
{
    [SerializeField] Slider hpBar;

    [SerializeField] UIPlayer1 uiplayer1;

    private void LateUpdate()
    {
        float hpPer = uiplayer1.Player1.HP / 100f;
        hpBar.value = hpPer;
    }
}
