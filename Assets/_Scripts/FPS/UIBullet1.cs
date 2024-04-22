using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 플레이어1의 탄환수를 보여줌
/// </summary>
public class UIBullet1 : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] UIPlayer1 uiplayer1;

    private void LateUpdate()
    {
        text.text = $"{uiplayer1.Player1.Weapon.curMagazine}/{uiplayer1.Player1.Weapon.maxMagazine}";
    }
}
