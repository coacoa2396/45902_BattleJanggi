using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerCheck : MonoBehaviour
{
    [SerializeField] EndScene endScene;
    [SerializeField] Image player1Win;
    [SerializeField] Image player2Win;

    private void Start()
    {
        if (endScene.Winner == "Han")
        {
            player1Win.gameObject.SetActive(true);
            player2Win.gameObject.SetActive(false);
        }
        else
        {
            player1Win.gameObject.SetActive(false);
            player2Win.gameObject.SetActive(true);
        }
    }
}
