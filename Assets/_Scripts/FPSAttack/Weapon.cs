using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 개발자: Yerin
/// 
/// Weapon 공통 내용
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] FPSPiece player;

    [Header("Property")]
    [SerializeField] float damage;
    [SerializeField] public int maxMagazine;       // 탄창이 꽉 차있는 경우 탄환의 수
    [SerializeField] public int curMagazine;       // 현재 탄창의 탄환 수

    public float Damage { get { return damage; } }

    protected virtual void Start()
    {
        player = GetComponentInParent<FPSPiece>();
    }

    public virtual void Fire() { }
}
