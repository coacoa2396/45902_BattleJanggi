using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// 제작 : 찬규
/// 장기씬의 데이터로드 관리
/// </summary>
public class JanggiLoadManager : MonoBehaviour
{
    /// <summary>
    /// 제작 : 찬규
    /// 타이틀에서 장기씬으로 넘어갈때 사용하는 초기세팅함수
    /// </summary>
    public void TitletoJanggi()
    {
        Manager.Data.LoadData(0);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {

        }
    }

    /// <summary>
    /// 제작 : 찬규
    /// fps씬에서 장기씬으로 넘어갈때 사용하는 함수
    /// </summary>
    public void FPStoJanggi()
    {
        Manager.Data.LoadData(1);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {
            if (piece.whosPiece.Equals("Han"))  // 한나라일 경우
            {
                switch (piece.pieceName)
                {
                    case "Cha":
                        Piece HanCha = Manager.Resource.Load<Piece>("Piece/Han/Cha(Han)");
                        Instantiate(HanCha, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Ma":
                        Piece HanMa = Manager.Resource.Load<Piece>("Piece/Han/Ma(Han)");
                        Instantiate(HanMa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sang":
                        Piece HanSang = Manager.Resource.Load<Piece>("Piece/Han/Sang(Han)");
                        Instantiate(HanSang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Po":
                        Piece HanPo = Manager.Resource.Load<Piece>("Piece/Han/Po(Han)");
                        Instantiate(HanPo, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sa":
                        Piece HanSa = Manager.Resource.Load<Piece>("Piece/Han/Sa(Han)");
                        Instantiate(HanSa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Jol(Bow)":
                        Piece HanJolBow = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Bow");
                        Instantiate(HanJolBow, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Jol(Pistol)":
                        Piece HanJolPistol = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Pistol");
                        Instantiate(HanJolPistol, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    //case "Jang":
                    //    Piece HanJang = Manager.Resource.Load<Piece>("Piece/Han/")
                }

            }
            else                                // 초나라일 경우
            {
                
            }

        }
    }
}
