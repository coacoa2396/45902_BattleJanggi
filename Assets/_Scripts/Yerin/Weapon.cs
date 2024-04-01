using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Yerin
/// 
/// Weapon 공통 내용
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Componemt")]
    [SerializeField] Animator animator;

    [Header("Property")]
    [SerializeField] float damage;

    public float Damage { get { return damage; } }

    public virtual void Fire() { }
}
