using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : BaseScene
{
    string winner;

    public string Winner { get { return winner; } }

    private void Awake()
    {
        if (Manager.Game.WhoWin == "Han")
        {
            winner = "Han";
        }
        else
        {
            winner = "Cho";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void GoTitle()
    {
        Manager.Scene.LoadScene("TitleScene");
    }    
}
