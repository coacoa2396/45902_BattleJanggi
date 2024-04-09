using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sang : Piece
{
    [SerializeField] LayerMask checkLayer;

    Spot curSpot;       // 현재 있는 스팟의 정보를 가져올 변수

    protected override void Start()
    {
        base.Start();
        pieceName = "Ma";
    }

    // spot과 만났을 때 해당 스팟의 포지션을 가져와서 본인의 포지션으로 초기화
    private void OnTriggerEnter(Collider other)
    {
        if (checkLayer.Contain(other.gameObject.layer))
        {
            curSpot = other.GetComponent<Spot>();
        }
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
        if (curSpot.ThisPos['z'] - 3 >= 0 && !JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece)    // 장기판을 벗어나지 않고 갈 수 있다면?
        {
            //  왼쪽 대각
            if (curSpot.ThisPos['x'] - 2 >= 0)  // 장기판을 벗어나지 않고
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece)           // 칸이 비어있으면                    
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))      // 왼대각 한번 더 체크
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2]);          // CanGoSpots 리스트에 넣고 색을 바꿔준다
                    }
                }
            }
            // 우측 대각
            if (curSpot.ThisPos['x'] + 2 <= 8)  // 장기판을 벗어나지 않고
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false)
                {
                    if (JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2].OnPiece == false ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2]);
                    }
                }
            }
        }

        // 오른쪽 칸을 갈 수 있는지 확인한다
        if (curSpot.ThisPos['x'] + 3 <= 8 && !JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] + 1].OnPiece)       // 장기판을 벗어나지 않고 갈 수 있다면?
        {
            // 윗 대각
            if (curSpot.ThisPos['z'] - 2 >= 0)      // 장기판을 벗어나지 않고
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].OnPiece)           // 칸이 비어있거나                     
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3]);
                    }
                }
            }
            // 아랫 대각
            if (curSpot.ThisPos['z'] + 2 <= 9)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3]);
                    }
                }
            }
        }

        // 아랫 칸을 갈 수 있는지 확인한다
        if (curSpot.ThisPos['z'] + 3 <= 9 && !JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x']].OnPiece)
        {
            // 우측 대각
            if (curSpot.ThisPos['x'] + 2 <= 8)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 1].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2]);
                    }
                }
            }
            // 좌측 대각
            if (curSpot.ThisPos['x'] - 2 >= 0)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 1].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2]);
                    }
                }
            }
        }

        // 왼쪽 칸을 갈 수 있는지 확인한다
        if (curSpot.ThisPos['x'] - 3 >= 0 && !JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] - 1].OnPiece)
        {
            // 아랫 대각
            if (curSpot.ThisPos['z'] + 2 <= 9)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3]);
                    }
                }
            }
            // 윗 대각
            if (curSpot.ThisPos['z'] - 2 >= 0)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3]);
                    }
                }
            }
        }
    }
}
