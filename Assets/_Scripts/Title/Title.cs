using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 타이틀씬에서 사용하는 기능들
/// </summary>
public class Title : BaseScene
{
    [SerializeField] GameObject SoundUI;

    bool isOn;

    bool isClicked;

    private void Start()
    {
        isOn = false;
        Manager.Sound.PlayBGM("BGM");
    }

    public void StartGame()
    {
        if (isClicked)
        {
            return;
        }

        isClicked = true;
        Manager.Game.GameWinReset();

        if (Manager.JanggiTurn != null && Manager.JanggiTurn.Turn > 1)
        {
            Manager.JanggiTurn.Turn = 1;
        }

        Manager.Scene.LoadScene("JanggiScene");
    }

    public void ClickOption()
    {
        if (!isOn)
        {
            isOn = true;
            SoundUI.SetActive(true);
        }
        else
        {
            isOn = false;
            SoundUI.SetActive(false);
        }
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
