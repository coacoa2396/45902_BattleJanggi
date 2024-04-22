using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowdownFloor : MonoBehaviour
{
    [SerializeField] LayerMask playerCheck;

    GameObject inPlayer;

    float playerSpeed;

    private void Start()
    {
        StartCoroutine(WaitDestroy());
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(5f);

        if (inPlayer != null ) 
        {
            inPlayer.GetComponent<FPSPiece>().MoveSpeed = playerSpeed;
            playerSpeed = 0;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (playerSpeed / 2 == other.GetComponent<FPSPiece>().MoveSpeed)
            {
                return;
            }

            playerSpeed = other.GetComponent<FPSPiece>().MoveSpeed;

            other.GetComponent<FPSPiece>().MoveSpeed = playerSpeed / 2;
            
            inPlayer = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (other.GetComponent<FPSPiece>().MoveSpeed == playerSpeed)
            {
                return;
            }

            other.GetComponent<FPSPiece>().MoveSpeed = playerSpeed;

            inPlayer = null;
            playerSpeed = 0f;
        }
    }
}
