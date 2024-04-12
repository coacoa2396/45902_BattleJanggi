using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 개발자: Yerin
/// 
/// FPS씬에서 장기씬으로 전환
/// </summary>
public class JanggiScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        Manager.Data.LoadData(0);
        //Manager.Data.GameData.pieceData
        yield return null;
    }

    public void SceneChange(string sceneName)
    {
        Manager.Scene.LoadScene(sceneName);
    }
}
