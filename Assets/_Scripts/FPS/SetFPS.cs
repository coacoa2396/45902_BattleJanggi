using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 예린
/// FPS시작시 장기턴에서 돌아가던 카운트를 멈춘다
/// </summary>
public class SetFPS : MonoBehaviour
{
    private void Start()
    {
        Manager.JanggiTurn.StopTurnCount();
        Manager.KillListManager.gameObject.SetActive(false);
    }
}
