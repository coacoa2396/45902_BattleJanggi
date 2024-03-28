using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    
    // 현재 위에 기물이 있는지 없는지?
    // 기물이 있다면
    // 기물의 레이어를 받아온다

    [SerializeField] LayerMask playerCheck;

    bool onPiece;
    string whosPiece;   // tag = cho, han 초나라 한다라

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // 기물이 있다면
        {
            onPiece = true;
            // 내 위에 기물의 태그를 가져옴
            whosPiece = other.gameObject.tag;
        }
    }

    

    /* 비교하는 함수
     * if(other.CompareTag("cho"))
            {
                // 초나라 기물임
            }
            else
            {
                // 한나라 기물임
            }
    */
}
