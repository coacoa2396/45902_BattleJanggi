using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSting : MonoBehaviour
{
    [SerializeField] float damage;

    // 충돌체크

    private void OnCollisionStay(Collision collision)
    {
        
    }

    // 충돌한 것이 플레이어인 경우 벽의 공격력만큼 플레이어에게 데미지
}
