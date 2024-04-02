using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 차(장기말) 관련 클래스
/// </summary>
public class Cha : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)

    protected override void Start()
    {
        base.Start();
        pieceName = "Cha";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            //transform.position = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        ChaLogic();
    }

    private void ChaLogic()
    {
        // 말의 x 좌표 기준 더 작은 쪽 검사

        for (int x = currentPos['x'] - 1; x >= 0; x--)
        {
            if (JanggiSituation[currentPos['z'], x].OnPiece)    // 찾는 경로에 말이 있는지 검사
            {
                if (JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // 내 말인지 검사
                {
                    break; 
                }
                else
                {
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], x]);

                    break;
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], x]);
            }
        }

        // 말의 x 좌표 기준 더 큰 쪽 검사

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {
            if (JanggiSituation[currentPos['z'], x].OnPiece)    // 찾는 경로에 말이 있는지 검사
            {
                if (JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // 내 말인지 검사
                {
                    break;
                }
                else
                {
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], x]);

                    break;
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], x]);
            }
        }

        // 말의 z 좌표 기준 더 작은 쪽 검사

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {
            if (JanggiSituation[z, currentPos['x']].OnPiece)    // 찾는 경로에 말이 있는지 검사
            {
                if (JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))   // 내 말인지 검사
                {
                    break;
                }
                else
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[z, currentPos['x']]);

                    break;
                }
            }
            else
            {
                JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[z, currentPos['x']]);
            }
        }

        // 말의 z 좌표 기준 더 큰 쪽 검사

        for (int z = currentPos['z'] - 1; z >= 0; z--)
        {
            if (JanggiSituation[z, currentPos['x']].OnPiece)    // 찾는 경로에 말이 있는지 검사
            {
                if (JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))   // 내 말인지 검사
                {
                    break;
                }
                else
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[z, currentPos['x']]);

                    break;
                }
            }
            else
            {
                JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[z, currentPos['x']]);
            }
        }
    }
}
