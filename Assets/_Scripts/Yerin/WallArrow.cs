using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 포(벽)에서 나가는 화살 관련 클래스
/// </summary>
public class WallArrow : MonoBehaviour
{
    [SerializeField] float damage;
    private void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(damage);

        gameObject.SetActive(false);
    }
}
