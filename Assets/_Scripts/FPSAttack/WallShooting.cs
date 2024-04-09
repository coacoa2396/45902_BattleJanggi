using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말 포의 벽
/// 일정 시간마다 화살 발사
/// </summary>
public class WallShooting : Wall
{
    [SerializeField] LayerMask playerCheck;
    [SerializeField] Animator animator;

    [SerializeField] PoAttackRange attackRange;
    [SerializeField] PoAttackRange nonAttackRange;

    [SerializeField] GameObject bow;

    [SerializeField] float rotSpeed;

    GameObject target;
    bool isTargeting;

    private void FixedUpdate()
    {
        if(isTargeting && target == null)
        {
            isTargeting = false;
            animator.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (attackRange.IsInTrigger)
            {
                if (nonAttackRange.IsInTrigger)
                {
                    SetData();
                }
                else
                {
                    SetData(other.gameObject);
                }
            }
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (!attackRange.IsInTrigger)
            {
                SetData();
            }
            else
            {
                SetData(other.gameObject);
            }
        }
    }
    void SetData(GameObject collider = null)
    {
        bool state = collider != null ? true : false;
        animator.enabled = state;
        isTargeting = state;
        target = collider;
    }

    private void OnTriggerStay(Collider other)  // Trigger 안에 있는 동안 캐릭터 바라보게 하기
    {
        if (playerCheck.Contain(other.gameObject.layer)) 
        {
            Vector3 dir = other.transform.position - bow.transform.position;
            Quaternion currentPos = bow.transform.rotation;

            float time = 0;

            while (time <= 1) //노말 값이 1이 아니면 반복한다.
            {
                float rotDeltaSpeed =  Time.deltaTime * rotSpeed;
                time += rotDeltaSpeed;
                //타겟 방향과 현재 바라 보고 있는 방향의 선형 비율을 가지고 노말 값을 통해 해당 지점의 변화량을 가져온다.
                Quaternion rot = Quaternion.Lerp(currentPos, Quaternion.LookRotation(dir), rotDeltaSpeed);
                bow.transform.rotation = rot; //가져온 변화량을 대입시킨다.
            }

            bow.transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}

