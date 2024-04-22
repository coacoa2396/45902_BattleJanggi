using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 각 씬들의 승리판정 체크
/// </summary>
public class GameManager : Singleton<GameManager>
{
    string fpsWin;          // fps 승리
    string gameWin;         // 전체 게임 승리

    public string FpsWin {  get { return fpsWin; } set { fpsWin = value; } }
    public string GameWin { get { return gameWin; } set { gameWin = value; } }

    public void FpsWinReset()
    {
        FpsWin = null;
    }

    public void GameWinReset()
    {
        GameWin = null;
    }

    public bool debugMode;
}
