using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveMaker : MonoBehaviour
{
    private GameData gameData;
    public GameData GameData { get { return gameData; } }

    private string setPath => Path.Combine(Application.dataPath, $"Resources/Data/FirstSet");

#if UNITY_EDITOR
    private string path => Path.Combine(Application.dataPath, $"Resources/Data/SaveLoad");
#else
    private string path => Path.Combine(Application.persistentDataPath, $"Resources/Data/SaveLoad");
#endif

    private void Start()
    {
        if (Manager.Data.ExistData(0))
            return;

        // FisrtSet을 불러와서 GameData에 저장한다
        string json = File.ReadAllText($"{setPath}/FirstSet.txt");
        gameData = JsonUtility.FromJson<GameData>(json);

        // 이 GameData를 다시 0번 Save로 만든다
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        string jsonSave = JsonUtility.ToJson(gameData, true);
        File.WriteAllText($"{path}/0.txt", jsonSave);
    }
}
