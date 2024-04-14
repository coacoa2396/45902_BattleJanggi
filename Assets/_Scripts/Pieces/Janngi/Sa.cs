using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������: Yerin
/// 
/// ��(��⸻) ���� Ŭ����
/// </summary>
public class Sa : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)

    protected override void Start()
    {
        base.Start();
        pieceName = "Sa";
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
        SaLogic();
    }

    private void SaLogic()
    {
        if (!Manager.JanggiTurn.CanGoOut)
        {
            // ���� ���� Ȯ��
            if (JanggiSituation[currentPos['z'], currentPos['x'] - 1].IsCastle)
            {
                checkLeft();
            }

            // ���� ������ Ȯ��

            if (JanggiSituation[currentPos['z'], currentPos['x'] + 1].IsCastle)
            {
                checkRight();
            }

            // ���� ���� Ȯ��

            if (currentPos['z'] != 0 && JanggiSituation[currentPos['z'] - 1, currentPos['x']].IsCastle)
            {
                checkForward();
            }

            // ���� ���� Ȯ��

            if (currentPos['z'] != 9 && JanggiSituation[currentPos['z'] + 1, currentPos['x']].IsCastle)
            {
                checkBack();
            }

            // ���� �ִ� Spot�� ���� ������

            if (JanggiSituation[currentPos['z'], currentPos['x']].ISCastleCenter)
            {
                CheckCentersDiagonals();

                return;
            }

            // �밢�� �ִ��� ���� Ȯ��

            if (JanggiSituation[currentPos['z'], currentPos['x']].DiagonalPos != null)
            {
                CheckDiagonal();
            }
        }
        else
        {
            // ���� ���� Ȯ��

            if (currentPos['x'] != 0)
            {
                checkLeft();
            }

            // ���� ������ Ȯ��

            if (currentPos['x'] != 8)
            {
                checkRight();
            }

            // ���� ���� Ȯ��

            if (currentPos['z'] != 0)
            {
                checkForward();
            }

            // ���� ���� Ȯ��

            if (currentPos['z'] != 9)
            {
                checkBack();
            }

            // ���� �ִ� Spot�� ���� ������

            if (JanggiSituation[currentPos['z'], currentPos['x']].ISCastleCenter)
            {
                CheckCentersDiagonals();

                return;
            }

            // �밢�� �ִ��� ���� Ȯ��

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
        // ���� �밢�� ��

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

        // ������ �밢�� ��

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

        // ���� �밢�� �Ʒ�

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

        // ������ �밢�� �Ʒ�

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
        // 한나라의 사가 죽었을 경우
        if (WhosPiece.Equals("Han"))
        {
            Manager.JanggiTurn.HanSa--;
        }
        // 초나라의 사가 죽었을 경우
        else
        {
            Manager.JanggiTurn.ChoSa--;
        }

        base.Die();
    }
}
