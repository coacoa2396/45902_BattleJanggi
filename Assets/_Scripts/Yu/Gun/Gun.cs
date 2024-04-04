using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : changyu
/// 탄환 발사형 무기들의 베이스
/// </summary>
public class Gun : Weapon
{
    [SerializeField] Bullet bullet;         // 총에서 나갈 탄환의 프리팹

    public Bullet Bullet {  get { return bullet; } }
}
