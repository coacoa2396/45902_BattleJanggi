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

    [SerializeField] string whosPiece;

    public string PieceName { get { return pieceName; }}

    public string WhosPiece { get { return whosPiece; } }

    protected virtual void Start()
    {
        pieceMaterial = gameObject.GetComponent<Renderer>().material;

        pieceName = "PP";
    }

    /// <summary>
    /// 해당 장기말 선택 시 장기판의 전체적인 상황 받아옴
    /// 플레이어가 장기말을 선택 시 해당 오브젝트의 색을 빨간색으로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        JanggiSituation = Manager.JanggiLogic.JanggiLogicSituation;

        if (JanggiSituation == null)
        {
            Debug.Log("Get JanggiLogic Fail");
        }

        pieceMaterial.color = Color.red;

        FindCanGo();
    }
    /// <summary>
    /// 플레이어가 해당 장기말 위에 마우스를 올릴 시 오브젝트의 색을 노란색으로 변경
    /// 선택할 수 있음을 알려주기 위해
    /// </summary>
    /// <param name="eventData"></param>

    public void OnPointerEnter(PointerEventData eventData)
    {
        pieceMaterial.color = Color.yellow;
    }

    /// <summary>
    /// 플레이어가 해당 장기말을 선택하지 않고 나왔을 시 오브젝트의 색을 원래대로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (pieceMaterial.color == Color.red)
        {
            return;
        }

        pieceMaterial.color = Color.white;
    }

    public virtual void FindCanGo()
    {

    }
}
