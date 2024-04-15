using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTime2 : MonoBehaviour
{
    [SerializeField] Image circle;
    [SerializeField] Image star;

    [SerializeField] TMP_Text text;

    float maxTimer = 30f;
    float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if ((int)timer == maxTimer)
        {
            timer = 0;
        }
    }

    private void LateUpdate()
    {
        text.text = $"{timer}";
    }

    public void CoolTimeCheck()
    {
        timer = 0;
        StartCoroutine(coolTime());
    }

    IEnumerator coolTime()
    {
        circle.color = new Color(0, 0, 0, 0.4f);
        star.color = new Color(0, 0, 0, 0.4f);
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(30f);

        circle.color = new Color(1, 1, 1, 1);
        star.color = new Color(1, 1, 1, 1);
        text.gameObject.SetActive(false);
    }
}
