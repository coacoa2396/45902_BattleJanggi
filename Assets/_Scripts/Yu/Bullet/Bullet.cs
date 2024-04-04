using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : ChanGyu
/// 총에서 나가는 탄환의 기본 베이스
/// </summary>
public class Bullet : PooledObject
{
    [Header("Component")]
    [SerializeField] Weapon weapon;

    [Header("Spec")]
    [SerializeField] float damage;
    [SerializeField] float speed;

    public float Damage { get { return damage; } set {  damage = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
}
