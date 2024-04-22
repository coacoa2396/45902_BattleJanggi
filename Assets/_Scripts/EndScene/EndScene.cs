using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 마지막 결과씬에서 사용되는 각종 함수들
/// </summary>
public class EndScene : BaseScene
{
    string winner;

    public string Winner { get { return winner; } }
    /// <summary>
    /// 게임매니저에서 승자가 누군지 받아온다
    /// </summary>
    private void Awake()
    {
        if (Manager.Game.GameWin == "Han")
        {
            winner = "Han";
        }
        else
        {
            winner = "Cho";
        }
    }
    /// <summary>
    /// 게임종료 기능
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
    /// <summary>
    /// 컨티뉴를 누르면 타이틀씬으로 가는 함수
    /// </summary>
    public void GoTitle()
    {
        Manager.Scene.LoadScene("TitleScene");
    }    
}
