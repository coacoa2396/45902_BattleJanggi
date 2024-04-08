using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoAttackRange : MonoBehaviour
{
    [SerializeField] LayerMask playerCheck;

    bool isInTrigger;

    public bool IsInTrigger { get { return isInTrigger; } }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            isInTrigger = false;
        }
    }
}
