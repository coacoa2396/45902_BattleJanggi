using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    string whoWin;

    public string WhoWin { get { return whoWin; } set { whoWin = value; } }

    public void Reset()
    {
        WhoWin = null;
    }
}
