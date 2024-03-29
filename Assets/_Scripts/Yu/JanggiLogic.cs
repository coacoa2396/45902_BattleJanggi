using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiLogic : Singleton<JanggiLogic>        // 싱글톤으로 만들어야함
{
    // 장기판은 가로 9, 세로 10 의 크기
    // 장기판의 2차원 배열을 만든다면 9x10의 배열을 생성해야함

    Spot[,] spots = new Spot[10, 9] 
    {
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null}
    };


    public Spot[,] JanggiLogicSituation { get { return spots; } }

    /// <summary>
    /// 장기씬이 시작될때 
    /// </summary>
    private void Start()
    {
        Spot[] children = GetComponentsInChildren<Spot>();
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 9; x++)
            {
                if (children[z * 9 + x] == null)
                {
                    Debug.Log($"Null ({x}, {z})");
                    break;
                }

                spots[z, x] = children[z * 9 + x];
                spots[z, x].SetPos(z, x);
            }
        }
    }
}
