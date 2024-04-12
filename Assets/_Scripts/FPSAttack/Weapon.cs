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

    public float Damage { get { return damage; } }

    protected virtual void Start()
    {
        player = GetComponentInParent<FPSPiece>();
    }

    public virtual void Fire() { }
}
