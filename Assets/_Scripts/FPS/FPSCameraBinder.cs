using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
