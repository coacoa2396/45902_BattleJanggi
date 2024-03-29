using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말의 기능 구현
/// </summary>
public class Piece : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// 해당 장기말 선택 시 장기판의 전체적인 상황 받아옴
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //JanggiLogic
    }

    // 클릭될 시 장기판 상황 가져오기 (포인터 이벤트 사용하기)
    // 클릭될 시 장기말 색깔 변형(일단은)
}
