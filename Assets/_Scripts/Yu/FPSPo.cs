using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: 찬규
/// 
/// 장기말(포) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 포의 스킬
/// </summary>
public class FPSPo : MonoBehaviour
{
    [SerializeField] LayerMask wallCheck;
    [SerializeField] CinemachineVirtualCamera skyCam;
    [SerializeField] ParticleSystem atomicBomb;

    bool isUsing;   // 스킬 사용중 체크

    private void Start()
    {
        isUsing = false;
    }

    public void OnSkill(InputValue value)
    {
        if (!isUsing)
        {
            skyCam.Priority = 50;
            isUsing = true;
        }
    }
}
