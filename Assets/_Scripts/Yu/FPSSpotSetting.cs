using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// FPS씬의 spot관리
/// </summary>
public class FPSSpotSetting : MonoBehaviour
{
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

    public Spot[,] FPSLogicSituation { get { return spots; } }

    private void Start()
    {
        Spot[] children = GetComponentsInChildren<Spot>();
        for (int z = 0; z < 10; z++)
        {
            for (int x = 0; x < 9; x++)
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
