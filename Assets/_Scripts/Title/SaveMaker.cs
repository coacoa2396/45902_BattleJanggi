using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveMaker : MonoBehaviour
{
    [SerializeField] TextAsset firstSet;

    private GameData gameData;
    public GameData GameData { get { return gameData; } }
        
#if UNITY_EDITOR
    private string path => Path.Combine(Application.dataPath, $"Resources/Data/SaveLoad");
#else
    private string path => Path.Combine(Application.persistentDataPath, $"Resources/Data/SaveLoad");
#endif

    private void Start()
    {
        // 0번 세이브가 존재하는지 확인
        if (Manager.Data.ExistData(0))
            return;

        // FisrtSet을 불러와서 GameData에 저장한다
        //string json = File.ReadAllText($"{setPath}/FirstSet.txt");
        string json = firstSet.text;
        if (json == null)
            Debug.LogError("Json is null!!");

        gameData = JsonUtility.FromJson<GameData>(json);

        // 이 GameData를 다시 0번 Save로 만든다
        if (Directory.Exists(path) == false)        // 폴더가 있는지 확인한다
        {
            Directory.CreateDirectory(path);
        }

        string jsonSave = JsonUtility.ToJson(gameData, true);
        File.WriteAllText($"{path}/0.txt", jsonSave);
    }
}
