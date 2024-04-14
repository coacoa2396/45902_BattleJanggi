using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규, 예린
/// </summary>
public class FPSLoadManager : MonoBehaviour
{
    [SerializeField] FPSSpotSetting spots;

    public void PieceLoad()
    {
        Manager.Data.LoadData(1);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {
            if (!piece.isPlayer1 || !piece.isPlayer2)       // 플레이어블 기물이 아니면 
            {
                // 기물의 이름을 체크
                switch (piece.pieceName)
                {
                    case "Cha":
                        Wall instanceCha = Manager.Resource.Load<Wall>("Wall/ChaWall_Complete");
                        Instantiate(instanceCha, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sang":
                        Wall instanceSang = Manager.Resource.Load<Wall>("Wall/SangWall_Complete");
                        Instantiate(instanceSang, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Ma":
                        Wall instanceMa = Manager.Resource.Load<Wall>("Wall/MaWall_Complete");

                        float y = 0;

                        if (piece.whosPiece.Equals("Cho"))
                        {
                            y = 180;
                        }

                        Instantiate(instanceMa, new Vector3(spots.FPSLogicSituation[piece.z, piece.x].transform.position.x, instanceMa.gameObject.transform.position.y, spots.FPSLogicSituation[piece.z, piece.x].transform.position.z), Quaternion.Euler(new Vector3(90, y, 0)));
                        break;
                    case "Po":
                        Wall instancePo;
                        y = 0;

                        if (piece.whosPiece.Equals("Han"))
                        {
                            instancePo = Manager.Resource.Load<Wall>("Wall/POWALL(Han)_Complete");
                        }
                        else
                        {
                            instancePo = Manager.Resource.Load<Wall>("Wall/POWALL(Cho)_Complete");
                            y = 180;
                        }

                        Instantiate(instancePo, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(new Vector3(0, y, 0)));
                        break;
                    case "Jang":

                        break;
                    default:
                        Wall instanceWall = Manager.Resource.Load<Wall>("Wall/BaseWALL_Complete"); ;
                        y = 0;

                        if (piece.whosPiece.Equals("Cho"))
                        {
                            y = 180;
                        }

                        Instantiate(instanceWall, new Vector3(spots.FPSLogicSituation[piece.z, piece.x].transform.position.x, instanceWall.gameObject.transform.position.y, spots.FPSLogicSituation[piece.z, piece.x].transform.position.z), Quaternion.Euler(new Vector3(90, y, 0)));
                        break;

                }
                // 해당 위치에 벽을 생성해주고
            }
            else
            {
                // 플레이어 기물을 해당 위치에 생성해줄거야
                if (piece.whosPiece == "Han")       // 기물이 한나라인 경우
                {
                    switch (piece.pieceName)
                    {
                        case "Cha":
                            FPSPiece fpsCha = Manager.Resource.Load<FPSPiece>("FPSPlayer/HanPlayer/FPSTiger_Han");
                            Instantiate(fpsCha, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                            break;
                    }
                }
                else                               // 기물이 초나라인 경우
                {

                }
            }
        }
    }
}
