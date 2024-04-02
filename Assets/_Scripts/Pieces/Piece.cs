using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말의 기능 구현
/// </summary>
public class Piece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected Spot[,] JanggiSituation;    // 현재 장기판 위 말의 상황을 받아 올 배열

    Material pieceMaterial; // 해당 장기말의 Material을 받을 변수

    protected string pieceName; // 장기말의 종류
    bool isClicked;  // 해당 말이 클릭됐는지 아닌지 판단하는 변수

    [SerializeField] string whosPiece;

    public string PieceName { get { return pieceName; }}
    public string WhosPiece { get { return whosPiece; } }
    public bool IsClicked { set { isClicked = value; } }


    List<Spot> CanGoSpots = new List<Spot>();

    protected virtual void Start()
    {
        pieceMaterial = gameObject.GetComponent<Renderer>().material;
    }

    /// <summary>
    /// 해당 장기말 선택 시 장기판의 전체적인 상황 받아옴
    /// 플레이어가 장기말을 선택 시 해당 오브젝트의 색을 빨간색으로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClicked)
        {
            JanggiLogic.Instance.ClickedPieceExist = false;

            pieceMaterial.color = Color.white;
            isClicked = false;

            DeleteList();

            return;
        }

        JanggiSituation = Manager.JanggiLogic.JanggiLogicSituation;

        if (JanggiSituation == null)
        {
            Debug.Log("Get JanggiLogic Fail");
        }

        if (JanggiLogic.Instance.ClickedPieceExist)  // 장기판에 다른 말이 이미 선택되어 있을 경우
        {
            JanggiLogic.Instance.ClickedPiece.pieceMaterial.color = Color.white;
            JanggiLogic.Instance.ClickedPiece.IsClicked = false;

            JanggiLogic.Instance.ClickedPiece.DeleteList();
        }

        JanggiLogic.Instance.ClickedPieceExist = true;
        JanggiLogic.Instance.ClickedPiece = this;

        pieceMaterial.color = Color.red;
        isClicked = true;

        FindCanGo();
    }
    /// <summary>
    /// 플레이어가 해당 장기말 위에 마우스를 올릴 시 오브젝트의 색을 노란색으로 변경
    /// 선택할 수 있음을 알려주기 위해
    /// </summary>
    /// <param name="eventData"></param>

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isClicked)
        {
            return;
        }

        pieceMaterial.color = Color.yellow;
    }

    /// <summary>
    /// 플레이어가 해당 장기말을 선택하지 않고 나왔을 시 오브젝트의 색을 원래대로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isClicked)
        {
            return;
        }

        pieceMaterial.color = Color.white;
    }

    /// <summary>
    /// 기물을 해당 spot의 위치로 옮기는 함수
    /// </summary>
    /// <param name="selectSpot"></param>
    public void MovePiece(Spot selectSpot)
    {
        transform.position = new Vector3(selectSpot.transform.position.x, transform.position.y, selectSpot.transform.position.z);

        JanggiLogic.Instance.ClickedPieceExist = false;

        pieceMaterial.color = Color.white;
        isClicked = false;

        DeleteList();
    }

    /// <summary>
    /// 갈 수있는 spot을 리스트에 넣고 빨간색으로 표시해준다
    /// </summary>
    /// <param name="destSpot"></param>
    public void AddList(Spot destSpot)
    {
        destSpot.GetComponent<Renderer>().material.color = Color.red;
        destSpot.ChaeckCanGo = true;
        destSpot.SetList(this);
        CanGoSpots.Add(destSpot);
    }

    /// <summary>
    /// 갈 수 있는 Spot을 저장한 리스트 전체 삭제
    /// </summary>
    public void DeleteList()
    {
        foreach (Spot spot in CanGoSpots)
        {
            Color color = new Color(0, 0, 0, 0);

            spot.gameObject.GetComponent<Renderer>().material.color = color;
        }

        CanGoSpots.Clear();
    }

    public virtual void FindCanGo()
    {

    }

}
