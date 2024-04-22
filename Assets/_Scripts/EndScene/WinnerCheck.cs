using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// 게임의 승자를 체크해서 UI를 띄운다
/// </summary>
public class WinnerCheck : MonoBehaviour
{
    [SerializeField] EndScene endScene;
    [SerializeField] Image player1Win;
    [SerializeField] Image player2Win;
    /// <summary>
    /// 엔드씬에 있는 승자변수를 받아와서 승리자의 UI를 띄워준다
    /// </summary>
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
