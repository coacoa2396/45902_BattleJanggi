using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 한나라와 초나라의 카메라를 설정하는 컴포넌트
/// </summary>
public class FPSCameraBinder : MonoBehaviour
{
    [SerializeField] Canvas aimCanvas;

    private void Start()
    {
        Camera[] cams = FindObjectsOfType<Camera>();
        if (gameObject.layer == LayerMask.NameToLayer("Han"))
        {
            for (int i = 0; i < cams.Length; i++)
            {
                if (!(cams[i].tag == "HanCamera"))
                    continue;
                aimCanvas.worldCamera = cams[i];
            }
        }
        else
        {
            for (int i = 0;i < cams.Length; i++)
            {
                if (!(cams[i].tag == "ChoCamera"))
                    continue;
                aimCanvas.worldCamera = cams[i];
            }
        }
    }
}
