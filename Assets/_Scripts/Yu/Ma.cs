using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ma : Piece
{
    [SerializeField] LayerMask checkLayer;

    Spot curSpot;       // 현재 있는 스팟의 정보를 가져올 변수

    List<Spot> CanGoSpots = new List<Spot>();

    // spot과 만났을 때 해당 스팟의 포지션을 가져와서 본인의 포지션으로 초기화
    private void OnTriggerEnter(Collider other)
    {
        if (checkLayer.Contain(other.gameObject.layer))
        {
            curSpot = other.GetComponent<Spot>();
        }
    }

    /// <summary>
    /// 갈수있는 spot을 리스트에 넣고 빨간색으로 표시해준다
    /// </summary>
    /// <param name="destSpot"></param>
    void AddList(Spot destSpot)
    {
        destSpot.GetComponent<Renderer>().material.color = Color.red;
        CanGoSpots.Add(destSpot);
    }

    public override void FindCanGo()
    {
        MaLogic();
    }

    void MaLogic()
    {
        if (curSpot == null)
        {
            Debug.Log("null");
            return;
        }
        // 앞 칸을 갈 수 있는지 확인한다
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece == false)    // 갈 수 있다면?
        {
            //  왼쪽 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece == false ||            // 칸이 비어있거나
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].WhosePiece.Equals(WhosPiece))  // 상대 기물이면
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1]);          // CanGoSpots 리스트에 넣고 색을 바꿔준다
            }
            // 우측 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false ||
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1]);
            }
        }

        // 오른쪽 칸을 갈 수 있는지 확인한다
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] + 1].OnPiece == false)       // 갈 수 있다면?
        {
            // 윗 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].OnPiece == false ||            // 칸이 비어있거나
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece)) // 상대 기물이면
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2]);
            }
            // 아랫 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].OnPiece == false ||
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2]);
            }
        }

        // 아랫 칸을 갈 수 있는지 확인한다
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece == false)
        {
            // 우측 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false ||
                Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1]);
            }
            // 좌측 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece == false ||
               Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1]);
            }
        }

        // 왼쪽 칸을 갈 수 있는지 확인한다
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] - 1].OnPiece == false)
        {
            // 아랫 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].OnPiece == false ||
                Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2]);
            }
            // 윗 대각
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].OnPiece == false ||
                Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2]);
            }
        }
    }
}

