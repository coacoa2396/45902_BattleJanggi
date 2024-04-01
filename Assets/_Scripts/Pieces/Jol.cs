using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 졸(장기말) 관련 클래스
/// </summary>
public class Jol : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)

    protected override void Start()
    {
        base.Start();
        pieceName = "Jol";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        JolLogic();
    }

    private void JolLogic()
    {
        // 말의 왼쪽 확인

        if (currentPos['x'] != 0)
        {
            if (JanggiSituation[currentPos['z'], currentPos['x'] - 1].OnPiece)
            {
                if (!JanggiSituation[currentPos['z'], currentPos['x'] - 1].WhosePiece.Equals(WhosPiece))
                {
                    JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
            }
        }

        // 말의 오른쪽 확인
        if (currentPos['x'] != 8)
        {
            if (JanggiSituation[currentPos['z'], currentPos['x'] + 1].OnPiece)
            {
                if (!JanggiSituation[currentPos['z'], currentPos['x'] + 1].WhosePiece.Equals(WhosPiece))
                {
                    JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
            }
        }

        // 말의 앞쪽 확인
        if (WhosPiece.Equals("Cho"))    // 초나라 말일 경우
        {
            if (currentPos['z'] == 9)
            {
                return;
            }

            if (JanggiSituation[currentPos['z'] + 1, currentPos['x']].OnPiece)  // 해당 경로에 말이 있는지 확인
            {
                if (!JanggiSituation[currentPos['z'] + 1, currentPos['x']].WhosePiece.Equals(WhosPiece))    // 상대편 말이면
                {
                    JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
            }
        }
        
        if (WhosPiece.Equals("Han"))    // 한나라 말일 경우
        {
            if (currentPos['z'] == 0)
            {
                return;
            }

            if (JanggiSituation[currentPos['z'] - 1, currentPos['x']].OnPiece)  // 해당 경로에 말이 있는지 확인
            {
                if (!JanggiSituation[currentPos['z'] - 1, currentPos['x']].WhosePiece.Equals(WhosPiece))    // 상대편 말이면
                {
                    JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
            }
        }
    }
}
