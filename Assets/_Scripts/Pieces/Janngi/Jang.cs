using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 개발자: Yerin
/// 
/// 장(장기말) 관련 클래스
/// </summary>
public class Jang : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)

    [SerializeField] UnityEvent OnJangDied;

    protected override void Start()
    {
        base.Start();
        pieceName = "Jang";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            transform.position = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        JangLogic();
    }

    private void JangLogic()
    {
        if (!Manager.JanggiTurn.CanGoOut)
        {
            // 말의 왼쪽 확인
            if (JanggiSituation[currentPos['z'], currentPos['x'] - 1].IsCastle)
            {
                checkLeft();
            }

            // 말의 오른쪽 확인

            if (JanggiSituation[currentPos['z'], currentPos['x'] + 1].IsCastle)
            {
                checkRight();
            }

            // 말의 앞쪽 확인

            if (currentPos['z'] != 0 && JanggiSituation[currentPos['z'] - 1, currentPos['x']].IsCastle)
            {
                checkForward();
            }

            // 말의 뒷쪽 확인

            if (currentPos['z'] != 9 && JanggiSituation[currentPos['z'] + 1, currentPos['x']].IsCastle)
            {
                checkBack();
            }

            // 지금 있는 Spot이 성의 가운데라면

            if (JanggiSituation[currentPos['z'], currentPos['x']].ISCastleCenter)
            {
                CheckCentersDiagonals();

                return;
            }

            // 대각선 있는지 여부 확인

            if (JanggiSituation[currentPos['z'], currentPos['x']].DiagonalPos != null)
            {
                CheckDiagonal();
            }
        }
        else
        {
            // 말의 왼쪽 확인

            if (currentPos['x'] != 0)
            {
                checkLeft();
            }

            // 말의 오른쪽 확인

            if (currentPos['x'] != 8)
            {
                checkRight();
            }

            // 말의 앞쪽 확인

            if (currentPos['z'] != 0)
            {
                checkForward();
            }

            // 말의 뒷쪽 확인

            if (currentPos['z'] != 9)
            {
                checkBack();
            }

            // 지금 있는 Spot이 성의 가운데라면

            if (JanggiSituation[currentPos['z'], currentPos['x']].ISCastleCenter)
            {
                CheckCentersDiagonals();

                return;
            }

            // 대각선 있는지 여부 확인

            if (JanggiSituation[currentPos['z'], currentPos['x']].DiagonalPos != null)
            {
                CheckDiagonal();
            }
        }
    }

    private void checkLeft()
    {
        if (JanggiSituation[currentPos['z'], currentPos['x'] - 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'], currentPos['x'] - 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
            }
        }
        else if (!JanggiSituation[currentPos['z'], currentPos['x'] - 1].OnPiece)
        {
            JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
        }
    }

    private void checkRight()
    {
        if (JanggiSituation[currentPos['z'], currentPos['x'] + 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'], currentPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
            }
        }
        else if (!JanggiSituation[currentPos['z'], currentPos['x'] + 1].OnPiece)
        {
            JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
        }
    }

    private void checkForward()
    {
        if (JanggiSituation[currentPos['z'] - 1, currentPos['x']].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] - 1, currentPos['x']].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
            }
        }
        else if (!JanggiSituation[currentPos['z'] - 1, currentPos['x']].OnPiece)
        {
            JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
        }
    }

    private void checkBack()
    {
        if (JanggiSituation[currentPos['z'] + 1, currentPos['x']].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] + 1, currentPos['x']].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
            }
        }
        else if (!JanggiSituation[currentPos['z'] + 1, currentPos['x']].OnPiece)
        {
            JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
        }
    }

    private void CheckCentersDiagonals()
    {
        // 왼쪽 대각선 위

        if (JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1]);
            }
        }
        else
        {
            JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x'] - 1]);
        }

        // 오른쪽 대각선 위

        if (JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1]);
            }
        }
        else
        {
            JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x'] + 1]);
        }

        // 왼쪽 대각선 아래

        if (JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1]);
            }
        }
        else
        {
            JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x'] - 1]);
        }

        // 오른쪽 대각선 아래

        if (JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1].OnPiece)
        {
            if (!JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1]);
            }
        }
        else
        {
            JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x'] + 1]);
        }
    }

    private void CheckDiagonal()
    {
        Dictionary<char, int> diagonalPos = JanggiSituation[currentPos['z'], currentPos['x']].DiagonalPos;

        if (JanggiSituation[diagonalPos['z'], diagonalPos['x']].OnPiece)
        {
            if (!JanggiSituation[diagonalPos['z'], diagonalPos['x']].WhosePiece.Equals(WhosPiece))
            {
                JanggiSituation[diagonalPos['z'], diagonalPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[diagonalPos['z'], diagonalPos['x']]);
            }
        }
        else
        {
            JanggiSituation[diagonalPos['z'], diagonalPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

            AddList(JanggiSituation[diagonalPos['z'], diagonalPos['x']]);
        }
    }

    public override void Die()
    {
        OnJangDied?.Invoke();
        base.Die();
    }
}
