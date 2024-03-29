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
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 9; x++)
            {
                if (GetComponentInChildren<Spot>() == null)
                {
                    Debug.Log($"Null ({x}, {z})");
                    break;
                }

                spots[z, x] = GetComponentInChildren<Spot>();
                spots[z, x].SetPos(z, x);
            }
        }

        /*bool cheak = true;

        foreach (Spot spot in spots)
        {
            if (spot == null)
            {
                Debug.Log("null is exist");
                Debug.Log(spot.name);
                cheak = false;
                break;
            }
        }

        if (cheak)
        {
            Debug.Log("Ok");
        }*/
    }

    void MaLogic()
    {
        // 앞 칸을 갈 수 있는지 확인한다
            // 갈 수 없다면 다음으로 넘어간다
            // 갈 수 있다면
                // 대각선을 확인한다
                    // 아군 기물이면 다음으로 넘어간다
                    // 빈 칸이거나 상대 기물이면 이동 가능 표시를 해준다


        // 오른쪽 칸을 갈 수 있는지 확인한다
            // 갈 수 없다면 다음으로 넘어간다
            // 갈 수 있다면
                // 대각선을 확인한다
                    // 아군 기물이면 다음으로 넘어간다
                    // 빈 칸이거나 상대 기물이면 이동 가능 표시를 해준다

        // 뒷 칸을 갈 수 있는지 확인한다
            // 갈 수 없다면 다음으로 넘어간다
            // 갈 수 있다면
                // 대각선을 확인한다
                    // 아군 기물이면 다음으로 넘어간다
                    // 빈 칸이거나 상대 기물이면 이동 가능 표시를 해준다

        // 왼쪽 칸을 갈 수 있는지 확인한다
            // 갈 수 없다면 다음으로 넘어간다
            // 갈 수 있다면
                // 대각선을 확인한다
                    // 아군 기물이면 다음으로 넘어간다
                    // 빈 칸이거나 상대 기물이면 이동 가능 표시를 해준다
    }
}
