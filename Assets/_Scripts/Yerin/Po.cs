using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Po : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // 현재 있는 Spot의 배열 위치 (== 말의 현재 위치)
    List<int> CanGoSpots;   // 갈 수 있는 Spot의 위치 저장

    protected override void Start()
    {
        base.Start();
        pieceName = "Po";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            // gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, gameObject.transform.position.y , other.gameObject.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        // 말의 x 좌표 기준 더 작은 쪽 검사

        if (currentPos['x'] == 0)
        {
            Debug.Log("Null");
            return;
        }

        for (int x = currentPos['x'] - 1; x >= 0 ; x--)
        {
            bool checkStop = false;

            Debug.Log("In");

            if (
                JanggiSituation[currentPos['z'], x].OnPiece &&
                !JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))
            {
                //Debug.Log("Help");
                Debug.Log("1");
                x--;
                for (; x >= 0; x--)
                {
                    Debug.Log($"({currentPos['z']},{x})");
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    if (JanggiSituation[currentPos['z'], x].OnPiece)
                    {
                        Debug.Log("2");
                        if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po") || JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            Debug.Log("3");
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            Debug.Log("4");
                            checkStop = true;
                            Debug.Log($"({currentPos['z']},{x})");
                            JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        }
                    }
                }
            }

            if (checkStop)
            {
                break;
            }
        }

        /*// 말의 x 좌표 기준 더 큰 쪽 검사

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {
            bool checkStop = false;

            if (JanggiSituation[currentPos['z'], x].OnPiece && !JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))
            {
                for (; x < 9; x++)
                {
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

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
                            break;
                        }
                    }
                }
            }

            if (checkStop)
            {
                break;
            }
        }

        // 말의 z 좌표 기준 더 작은 쪽 검사

        for (int z = 0; z < currentPos['z']; z++)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece && !JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
            {
                for (; z < currentPos['z']; z++)
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

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
                            break;
                        }
                    }
                }
            }

            if (checkStop)
            {
                break;
            }
        }

        // 말의 z 좌표 기준 더 큰 쪽 검사

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece && !JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
            {
                for (; z < 10; z++)
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

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
                            break;
                        }
                    }
                }
            }

            if (checkStop)
            {
                break;
            }
        }*/
    }
}
