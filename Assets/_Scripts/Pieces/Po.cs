using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Yerin
/// 
/// 포(장기말) 관련 클래스
/// </summary>

public class Po : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)

    protected override void Start()
    {
        base.Start();
        pieceName = "Po";
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
        PoLogic();
    }

    private void PoLogic()
    {
        // 말의 x 좌표 기준 더 작은 쪽 검사

        for (int x = currentPos['x'] - 1; x >= 0; x--)
        {
            bool checkStop = false;     // 검사 필요 여부 확인 변수

            if (JanggiSituation[currentPos['z'], x].OnPiece)    // 찾는 경로에 말이 있는지 검사
            {
                if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))   // 있는 말이 포인지 검사
                {
                    break;  // 포일시 중단
                }

                x--;

                for (; x >= 0; x--)
                {
                    if (JanggiSituation[currentPos['z'], x].OnPiece)    // 건넌 뛴 너머에 말이 있는지 검사
                    {
                        if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po") || JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // 말이 포거나 내 말일 경우
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))     // 말이 상대팀 말일 경우
                        {
                            checkStop = true;
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
            }

            if (checkStop)
            {
                break;
            }
        }

        // 말의 x 좌표 기준 더 큰 쪽 검사

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {
            bool checkStop = false;

            if (JanggiSituation[currentPos['z'], x].OnPiece)
            {
                if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                x++;

                for (; x < 9; x++)
                {
                    if (JanggiSituation[currentPos['z'], x].OnPiece)
                    {
                        if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po") || JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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
            }

            if (checkStop)
            {
                break;
            }
        }

        // 말의 z 좌표 기준 더 작은 쪽 검사

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece)
            {
                if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                z++;

                for (; z < 10; z++)
                {
                    if (JanggiSituation[z, currentPos['x']].OnPiece)
                    {
                        if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po") || JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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

            if (checkStop)
            {
                break;
            }
        }

        // 말의 z 좌표 기준 더 큰 쪽 검사

        for (int z = currentPos['z'] - 1; z >= 0; z--)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece)
            {
                if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                z--;

                for (; z >= 0; z--)
                {
                    if (JanggiSituation[z, currentPos['x']].OnPiece)
                    {
                        if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po") || JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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

            if (checkStop)
            {
                break;
            }
        }
    }
}
