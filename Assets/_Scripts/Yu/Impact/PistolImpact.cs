using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolImpact : Impact
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
