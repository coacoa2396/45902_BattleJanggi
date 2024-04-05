using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSScene : BaseScene
{
    [SerializeField] Bullet[] bullets;
    [SerializeField] Impact[] impacts;

    private void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            Manager.Pool.CreatePool(bullets[i], 128, 512);
        }

        for (int i = 0;i < impacts.Length;i++)
        {
            Manager.Pool.CreatePool(impacts[i], 128, 512);
        }
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void SceneChange(string sceneName)
    {
        Manager.Scene.LoadScene(sceneName);
    }


}
