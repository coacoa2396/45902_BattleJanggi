using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPS : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        Manager.Scene.LoadScene(sceneName);
    }
}
