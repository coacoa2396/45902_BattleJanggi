using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Po : Piece
{
    [SerializeField] LayerMask cheakSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)
    List<int> CanGoSpots;   // 갈 수 있는 Spot의 위치 저장
    private void OnTriggerEnter(Collider other)
    {
        if (cheakSpot.Contain(other.gameObject.layer))
        {
            // gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, gameObject.transform.position.y , other.gameObject.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        // 말의 x 좌표 기준 더 작은 쪽 검사

        for (int x = 0; x < currentPos['x']; x++)
        {

        }

        // 말의 x 좌표 기준 더 큰 쪽 검사

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {

        }

        // 말의 z 좌표 기준 더 작은 쪽 검사

        for (int z = 0; z < currentPos['z']; z++)
        {

        }

        // 말의 z 좌표 기준 더 큰 쪽 검사

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {

        }
    }
}
