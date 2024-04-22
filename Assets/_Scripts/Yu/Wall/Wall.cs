using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 벽의 기본 베이스
/// </summary>
public class Wall : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
