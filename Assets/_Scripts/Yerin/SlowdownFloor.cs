using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownFloor : MonoBehaviour
{
    [SerializeField] LayerMask playerCheak;

    IEnumerator SlowDown(GameObject player)
    {
        player.GetComponent<FPSPiece>().MoveSpeed = player.GetComponent<FPSPiece>().MoveSpeed * 0.5f;

        yield return new WaitForSeconds(5f);

        player.GetComponent<FPSPiece>().MoveSpeed = player.GetComponent<FPSPiece>().MoveSpeed * 2f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheak.Contain(other.gameObject.layer))
        {
            StartCoroutine(SlowDown(other.gameObject));
        }
    }
}
