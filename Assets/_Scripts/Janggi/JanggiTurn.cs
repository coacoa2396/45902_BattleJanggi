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

    float baseTime = 60;
    float timer;
    int turn;       // 턴 수 체크
    int hanSa = 2;  // 한나라의 사의 개수
    int choSa = 2;  // 초나라의 사의 개수

    bool canGoOut;

    Coroutine timeLimit;

    public string CurrentTurn { get { return currentTurn; } }
    public bool CanGoOut { get {  return canGoOut; } }
    public float Timer {  get { return timer; } }
    public int Turn { get { return turn; } set { turn = value; } }
    public int HanSa { get {  return hanSa; } set {  hanSa = value; } }
    public int ChoSa { get { return choSa; } set {  choSa = value; } }

    private void Start()
    {
        currentTurn = Han;

        timer = baseTime;
        turn = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
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
            turn++;
            timer = baseTime;
        }
        else if (currentTurn.Equals(Cho))   // 현재 플레이어가 초나라일 시
        {
            currentTurn = Han;
            turn++;
            timer = baseTime;
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

    public void StopTurnCount()
    {
        StopCoroutine(timeLimit);
    }

    public void StartTurnCount()
    {
        timeLimit = StartCoroutine(CountTime());
    }
}