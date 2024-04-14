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

    private void Start()
    {
        isOn = false;
        Manager.Sound.PlayBGM("BGM");
    }

    public void StartGame()
    {
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
