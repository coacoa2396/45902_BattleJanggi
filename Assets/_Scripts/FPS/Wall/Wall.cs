using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// ���� �⺻ ���̽�
/// </summary>
public class Wall : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}