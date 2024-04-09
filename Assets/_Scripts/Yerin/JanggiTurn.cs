using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기 씬 플로우 - 플레이어 턴 구현 클래스
/// </summary>
public class JanggiTurn : Singleton<JanggiTurn>
{
    string currentTurn;

    string Han = "Han";
    string Cho = "Cho";

    float time;

    Coroutine timeLimit;

    public string CurrentTurn { get { return currentTurn; } }

    private void Start()
    {
        currentTurn = Han;
        time = 0;

        timeLimit = StartCoroutine(CountTime());
    }
    /// <summary>
    /// 현재 누구의 턴인지 확인하는 함수 
    /// 자신의 턴이면 true를, 아닐 시 false를 리턴
    /// </summary>
    /// <param name="player"> 플레이어 팀명</param>
    /// <returns></returns>
    public bool CheckWhosTurn(string player)
    {
        if (player == null || currentTurn == null)
        {
            Debug.LogError("현재 누구의 턴인지 확인할 수 없습니다.");
            return false;
        }

        if (player.Equals(currentTurn))
        {
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// 장기 씬 플레이어의 턴을 만드는 함수 
    /// </summary>
    public void OnTurn() 
    {
        StopCoroutine(timeLimit);

        if (currentTurn.Equals(Han))    // 현재 플레이어가 한나라일 시
        {
            currentTurn = Cho;
        }
        else if (currentTurn.Equals(Cho))   // 현재 플레이어가 초나라일 시
        {
            currentTurn = Han;
        }
        else
        {
            Debug.LogError("현재 옳바르지 않는 플레이어 팀명이 데이터로 입력되어 있습니다.");
            return;
        }

        timeLimit = StartCoroutine(CountTime());
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(60.0f);

        Debug.Log("시간 초과 발생");

        if (Manager.JanggiLogic.ClickedPieceExist)  // 장기말을 선택한 상태에서 시간초과 발생 시
        {
            Manager.JanggiLogic.ClickedPieceExist = false;

            Manager.JanggiLogic.ClickedPiece.PieceMaterial.color = Color.white;
            Manager.JanggiLogic.ClickedPiece.IsClicked = false;

            Manager.JanggiLogic.ClickedPiece.DeleteList();
        }

        OnTurn();
        Manager.JanggiCamera.CameraMoveLow();
    }
}

/*
 * 플레이어 턴 구현을 위한 고민 판
 * 
 * 1. 현재 턴이 누구의 턴인지 확인 - 현재 각 말마다 String 달아둠 - 이걸로 확인하면 됨.
 * 고민 1. 이런 건 JanggiScene의 매니저에서 하는 게 맞지 않나...? -> 싱글톤 (완료)
 * 
 * 2. 턴에 해당되는 이 쪽으로 넘어가기 (첫 시작은 한나라에서 시작) (완료)
 * 
 * 3. 시간 초과(60초) 넘어가면 다른 사람 턴으로 이동 (완료)
 * 
 * 4. 비스듬하게 보여주다 말을 선택하면 위로 올라가기
 * 
 * 5. 말을 취소하면 다시 비스듬하게, 말의 이동할 곳을 선택하면 그 곳으로의 이동을 보여준 후 다음 턴의 사람으로 이동
 * 
 * 6. 이를 게임 종료 때까지 반복
 */