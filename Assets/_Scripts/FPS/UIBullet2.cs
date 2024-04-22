using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 플레이어2의 탄환수를 보여줌
/// </summary>
public class UIBullet2 : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] UIPlayer2 uiplayer2;

    private void LateUpdate()
    {
        text.text = $"{uiplayer2.Player2.Weapon.curMagazine}/{uiplayer2.Player2.Weapon.maxMagazine}";
    }
}
