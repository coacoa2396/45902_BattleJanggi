using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiLogic : MonoBehaviour
{
    [SerializeField] Spot spotPrefab;

    // 장기판은 가로 9, 세로 10 의 크기
    // 장기판의 2차원 배열을 만든다면 9x10의 배열을 생성해야함

    Spot[,] array = new Spot[10, 9] 
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

    

    private void Start()
    {
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 9; x++)
            {
                array[z, x] = GetComponent<Spot>();
            }
        }
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
