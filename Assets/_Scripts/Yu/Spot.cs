using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ChanGyu
/// </summary>
public class Spot : MonoBehaviour, IPointerClickHandler
{
    // 현재 위에 기물이 있는지 없는지?
    // 기물이 있다면
    // 기물의 레이어를 받아온다

    [SerializeField] LayerMask playerCheck;

    Piece whatPiece;        // 현재 위에 있는 기물
    Dictionary<char, int> thisPos;
    Piece listPiece;

    bool inList;
    bool onPiece;
    bool checkCanGo;           // 갈수있는 체크리스트에 포함이 되었는지 체크

    [SerializeField] bool isCastle; // 성에 있는 Spot인지 아닌지
    [SerializeField] bool isCastleCenter;   // 성 가운데에 있는 Spot인지 아닌지
    [SerializeField] bool diagonal = false; // Spot 근처 대각선 유무
    Dictionary<char, int> diagonalPos = null;  // 대각선 Spot 배열 위치
    [SerializeField] int diagonalX;
    [SerializeField] int diagonalZ;

    string whosPiece;   // Cho, Han 초나라 한나라

    public Piece WhatPiece { get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece; } set { whosPiece = value; } }
    public bool InList { get { return inList; } set { inList = value; } }
    public bool OnPiece { get { return onPiece; } }
    public bool CheckCanGo { get { return checkCanGo; } set { checkCanGo = value; } }
    public Piece ListPiece { get { return listPiece; } }
    public Dictionary<char, int> ThisPos { get { return thisPos; } }
    public bool IsCastle { get { return isCastle; } }
    public bool ISCastleCenter { get { return isCastleCenter; } }
    public Dictionary<char, int> DiagonalPos { get { return diagonalPos; } }
    private void Start()
    {
        thisPos = new Dictionary<char, int>();

        thisPos.Add('z', 0);
        thisPos.Add('x', 0);

        inList = false;

        if (isCastle && diagonal)
        {
            diagonalPos = new Dictionary<char, int>();

            diagonalPos.Add('x', diagonalX);
            diagonalPos.Add('z', diagonalZ);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // 기물이 있다면
        {
            // 기물이 위에 있다는 bool을 true로 바꿔준다
            onPiece = true;
            // 내 위에 기물의 팀을 가져옴
            whosPiece = other.gameObject.GetComponent<Piece>().WhosPiece;
            // 어떤 기물인지 받아오기
            whatPiece = other.GetComponent<Piece>();
            // 내 위에 기물에 현재spot 세팅하기
            other.gameObject.GetComponent<Piece>().SetUnderSpot(this);
        }
    }

    private void OnTriggerExit(Collider other)              // 기물이 없다면
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            onPiece = false;
            whosPiece = null;
            whatPiece = null;
        }
    }

    /// <summary>
    /// 각 spot이 자기자신의 위치를 기억하게 하는 함수
    /// </summary>
    /// <param name="z"></param>
    /// <param name="x"></param>
    public void SetPos(int z, int x)
    {
        thisPos['z'] = z;
        thisPos['x'] = x;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!checkCanGo)
            return;

        listPiece.MovePiece(this);
    }

    /// <summary>
    /// spot이 들어가있는 list를 가지고 있는 기물을 세팅
    /// </summary>
    /// <param name="listPiece"></param>
    public void SetList(Piece listPiece)
    {
        this.listPiece = listPiece;
    }

    public void ClickMove()
    {
        if (!checkCanGo)
            return;

        listPiece.MovePiece(this);

        listPiece = null;
    }
}
