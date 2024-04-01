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

    Piece whatPiece;
    Dictionary<char, int> thisPos;
    Piece listPiece;

    [SerializeField] bool onPiece;
    [SerializeField] bool checkCanGo;           // 갈수있는 체크리스트에 포함이 되었는지 체크
    string whosPiece;   // tag = cho, han 초나라 한나라

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }
    public bool OnPiece { get { return onPiece; } }
    public bool ChaeckCanGo { get { return checkCanGo; } set { checkCanGo = value; } }
    public Dictionary<char, int> ThisPos { get { return thisPos; } }

    private void Start()
    {
        thisPos = new Dictionary<char, int>();

        thisPos.Add('z', 0);
        thisPos.Add('x', 0);
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
}
