using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// 제작 : 찬규, 예린
/// 장기씬의 데이터로드 관리
/// </summary>
public class JanggiLoadManager : Singleton<JanggiLoadManager>
{
    public void LoadStart()
    {
        if (Manager.JanggiTurn.Turn <= 1)
        {
            TitletoJanggi();
            Manager.KillListManager.SetImageNum();
            Manager.KillListManager.gameObject.SetActive(true);
        }
        else
        {
            FPStoJanggi();
        }
    }
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
            if (piece.whosPiece.Equals("Han"))  // 한나라일 경우
            {
                switch (piece.pieceName)
                {
                    case "Cha":
                        Piece HanCha = Manager.Resource.Load<Piece>("Piece/Han/Cha(Han)");
                        Instantiate(HanCha, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                    case "Ma":
                        Piece HanMa = Manager.Resource.Load<Piece>("Piece/Han/Ma(Han)");
                        Instantiate(HanMa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                    case "Sang":
                        Piece HanSang = Manager.Resource.Load<Piece>("Piece/Han/Sang(Han)");
                        Instantiate(HanSang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                    case "Po":
                        Piece HanPo = Manager.Resource.Load<Piece>("Piece/Han/Po(Han)");
                        Instantiate(HanPo, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                    case "Sa":
                        Piece HanSa = Manager.Resource.Load<Piece>("Piece/Han/Sa(Han)");
                        Instantiate(HanSa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                    case "Jol":
                        if (piece.jolWeapon == "Bow")
                        {
                            Piece HanJolBow = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Bow");
                            Instantiate(HanJolBow, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                            break;
                        }
                        else
                        {
                            Piece HanJolPistol = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Pistol");
                            Instantiate(HanJolPistol, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                            break;
                        }
                    case "Jang":
                        Piece HanJang = Manager.Resource.Load<Piece>("Piece/Han/Jang(Han)");
                        Instantiate(HanJang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        break;
                }

            }
            else                                // 초나라일 경우
            {
                switch (piece.pieceName)
                {
                    case "Cha":
                        Piece ChoCha = Manager.Resource.Load<Piece>("Piece/Cho/Cha(Cho)");
                        Instantiate(ChoCha, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Ma":
                        Piece ChoMa = Manager.Resource.Load<Piece>("Piece/Cho/Ma(Cho)");
                        Instantiate(ChoMa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sang":
                        Piece ChoSang = Manager.Resource.Load<Piece>("Piece/Cho/Sang(Cho)");
                        Instantiate(ChoSang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Po":
                        Piece ChoPo = Manager.Resource.Load<Piece>("Piece/Cho/Po(Cho)");
                        Instantiate(ChoPo, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sa":
                        Piece ChoSa = Manager.Resource.Load<Piece>("Piece/Cho/Sa(Cho)");
                        Instantiate(ChoSa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Jol":
                        if (piece.jolWeapon == "Bow")
                        {
                            Piece ChoJolBow = Manager.Resource.Load<Piece>("Piece/Cho/Jol(Cho)Bow");
                            Instantiate(ChoJolBow, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                            break;
                        }
                        else
                        {
                            Piece ChoJolPistol = Manager.Resource.Load<Piece>("Piece/Cho/Jol(Cho)Pistol");
                            Instantiate(ChoJolPistol, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                            break;
                        }
                    case "Jang":
                        Piece ChoJang = Manager.Resource.Load<Piece>("Piece/Cho/Jang(Cho)");
                        Instantiate(ChoJang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                }
            }
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
        Piece FPS1 = null;
        Piece FPS2 = null;
        Spot FPS1Spot = null;
        Spot FPS2Spot = null;

        foreach (PiecePosData piece in data.pieces)
        {
            if (piece.whosPiece.Equals("Han"))  // 한나라일 경우
            {
                switch (piece.pieceName)
                {
                    case "Cha":
                        Piece HanCha = Manager.Resource.Load<Piece>("Piece/Han/Cha(Han)");
                        Piece _HanCha = Instantiate(HanCha, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        _HanCha.ImageNum = piece.imageNum;
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanCha;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Ma":
                        Piece HanMa = Manager.Resource.Load<Piece>("Piece/Han/Ma(Han)");
                        Piece _HanMa = Instantiate(HanMa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        _HanMa.ImageNum = piece.imageNum;
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanMa;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Sang":
                        Piece HanSang = Manager.Resource.Load<Piece>("Piece/Han/Sang(Han)");
                        Piece _HanSang = Instantiate(HanSang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        _HanSang.ImageNum = piece.imageNum;
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanSang;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Po":
                        Piece HanPo = Manager.Resource.Load<Piece>("Piece/Han/Po(Han)");
                        Piece _HanPo = Instantiate(HanPo, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        _HanPo.ImageNum = piece.imageNum;
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanPo;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Sa":
                        Piece HanSa = Manager.Resource.Load<Piece>("Piece/Han/Sa(Han)");
                        Piece _HanSa = Instantiate(HanSa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        _HanSa.ImageNum = piece.imageNum;
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanSa;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Jol":
                        if (piece.jolWeapon == "Bow")
                        {
                            Piece HanJolBow = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Bow");
                            Piece _HanJolBow = Instantiate(HanJolBow, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                            _HanJolBow.ImageNum = piece.imageNum;
                            if (piece.isPlayer1 == true)
                            {
                                FPS1 = _HanJolBow;
                                FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                            }
                            break;
                        }
                        else
                        {
                            Piece HanJolPistol = Manager.Resource.Load<Piece>("Piece/Han/Jol(Han)Pistol");
                            Piece _HanJolPistol = Instantiate(HanJolPistol, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                            _HanJolPistol.ImageNum = piece.imageNum;
                            if (piece.isPlayer1 == true)
                            {
                                FPS1 = _HanJolPistol;
                                FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                            }
                            break;
                        }
                    case "Jang":
                        Piece HanJang = Manager.Resource.Load<Piece>("Piece/Han/Jang(Han)");
                        Piece _HanJang = Instantiate(HanJang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.Euler(0, 180, 0));
                        if (piece.isPlayer1 == true)
                        {
                            FPS1 = _HanJang;
                            FPS1Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                }
            }
            else                                // 초나라일 경우
            {
                switch (piece.pieceName)
                {
                    case "Cha":
                        Piece ChoCha = Manager.Resource.Load<Piece>("Piece/Cho/Cha(Cho)");
                        Piece _ChoCha = Instantiate(ChoCha, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        _ChoCha.ImageNum = piece.imageNum;
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoCha;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Ma":
                        Piece ChoMa = Manager.Resource.Load<Piece>("Piece/Cho/Ma(Cho)");
                        Piece _ChoMa = Instantiate(ChoMa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        _ChoMa.ImageNum = piece.imageNum;
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoMa;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Sang":
                        Piece ChoSang = Manager.Resource.Load<Piece>("Piece/Cho/Sang(Cho)");
                        Piece _ChoSang = Instantiate(ChoSang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        _ChoSang.ImageNum = piece.imageNum;
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoSang;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Po":
                        Piece ChoPo = Manager.Resource.Load<Piece>("Piece/Cho/Po(Cho)");
                        Piece _ChoPo = Instantiate(ChoPo, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        _ChoPo.ImageNum = piece.imageNum;
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoPo;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Sa":
                        Piece ChoSa = Manager.Resource.Load<Piece>("Piece/Cho/Sa(Cho)");
                        Piece _ChoSa = Instantiate(ChoSa, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        _ChoSa.ImageNum = piece.imageNum;
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoSa;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                    case "Jol":
                        if (piece.jolWeapon == "Bow")
                        {
                            Piece ChoJolBow = Manager.Resource.Load<Piece>("Piece/Cho/Jol(Cho)Bow");
                            Piece _ChoJolBow = Instantiate(ChoJolBow, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                            _ChoJolBow.ImageNum = piece.imageNum;
                            if (piece.isPlayer2 == true)
                            {
                                FPS2 = _ChoJolBow;
                                FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                            }
                            break;
                        }
                        else
                        {
                            Piece ChoJolPistol = Manager.Resource.Load<Piece>("Piece/Cho/Jol(Cho)Pistol");
                            Piece _ChoJolPistol = Instantiate(ChoJolPistol, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                            _ChoJolPistol.ImageNum = piece.imageNum;
                            if (piece.isPlayer2 == true)
                            {
                                FPS2 = _ChoJolPistol;
                                FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                            }
                            break;
                        }
                    case "Jang":
                        Piece ChoJang = Manager.Resource.Load<Piece>("Piece/Cho/Jang(Cho)");
                        Piece _ChoJang = Instantiate(ChoJang, Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        if (piece.isPlayer2 == true)
                        {
                            FPS2 = _ChoJang;
                            FPS2Spot = Manager.JanggiLogic.JanggiLogicSituation[piece.z, piece.x];
                        }
                        break;
                }
            }
        }

        if (FPS1 == null || FPS2 == null)
        {
            Debug.Log("오류");
        }

        Debug.Log(Manager.Game.FpsWin);
        Debug.Log(Manager.JanggiTurn.CurrentTurn);

        // FPS 승리 패배 구현
        if (Manager.JanggiTurn.CurrentTurn == "Cho")        // 한나라의 턴인 경우
        {
            if (Manager.Game.FpsWin.Equals("Han"))           // 한나라 기물이 이겼을 때
            {

                FPS2.Die();
                FPS1.transform.position = new Vector3(FPS2Spot.transform.position.x, FPS1.transform.position.y, FPS2Spot.transform.position.z);
            }
            else                                            // 초나라 기물이 이겼을 때
            {
                FPS1.Die();
            }
        }
        else                                                // 초나라의 턴인 경우
        {
            if (Manager.Game.FpsWin.Equals("Han"))           // 한나라 기물이 이겼을 때
            {
                FPS2.Die();
            }
            else                                            // 초나라 기물이 이겼을 때
            {
                FPS1.Die();
                FPS2.transform.position = new Vector3(FPS1Spot.transform.position.x, FPS2.transform.position.y, FPS1Spot.transform.position.z);
            }
        }
    }
}
