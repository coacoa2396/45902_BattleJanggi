using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������: Yerin
/// 
/// Weapon ���� ����
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] FPSPiece player;

    [Header("Property")]
    [SerializeField] float damage;
    [SerializeField] public int maxMagazine;       // źâ�� �� ���ִ� ��� źȯ�� ��
    [SerializeField] public int curMagazine;       // ���� źâ�� źȯ ��

    public float Damage { get { return damage; } }

    protected virtual void Start()
    {
        player = GetComponentInParent<FPSPiece>();
    }

    public virtual void Fire() { }
}
