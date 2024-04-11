using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Bullet
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float range;
    [SerializeField, Range(0, 360)] float angle;
    [SerializeField] int damage;

    private float preAngle;
    private float cosAngle;
    private float CosAngle;

    Collider[] colliders = new Collider[20];

    private void AttackTiming()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        for (int i = 0; i < size; i++)
        {
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirToTarget) < CosAngle)
                continue;

            FPSPiece player = colliders[i].GetComponent<FPSPiece>();
            player?.TakeDamage(damage);
        }
    }
}
