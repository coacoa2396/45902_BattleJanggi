using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaLazerRenderer : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(0.3f);

        gameObject.SetActive(false);
    }
}
