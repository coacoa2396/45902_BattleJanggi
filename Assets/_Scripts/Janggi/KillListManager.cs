using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기씬 잡은 말 표시 UI를 위한 싱글톤
/// </summary>

public class KillListManager : Singleton<KillListManager>
{
    [SerializeField] GameObject hanFirst;
    [SerializeField] GameObject hanSecond;
    [SerializeField] GameObject choFirst;
    [SerializeField] GameObject choSecond;

    [SerializeField] Image[] hanImage;
    [SerializeField] Image[] choImage;

    public Image[] HanImage { get { return hanImage; } }
    public Image[] ChoImage { get { return choImage; } }

    private void Start()
    {
        hanImage = new Image[15];
        choImage = new Image[15];

        int count = 0;

        foreach (Image image in hanFirst.transform.GetComponentsInChildren<Image>())
        {
            hanImage[count++] = image;
        }

        foreach (Image image in hanSecond.transform.GetComponentsInChildren<Image>())
        {
            hanImage[count++] = image;
        }

        count = 0;

        foreach (Image image in choFirst.transform.GetComponentsInChildren<Image>())
        {
            choImage[count++] = image;
        }

        foreach (Image image in choSecond.transform.GetComponentsInChildren<Image>())
        {
            choImage[count++] = image;
        }
    }

    public void SetImageNum()
    {
        int hanCount = 0;
        int choCount = 0;

        foreach (Cha cha in FindObjectsOfType<Cha>())   // cha
        {
            if (cha.WhosPiece.Equals("Han"))
            {
                cha.ImageNum = hanCount++;
            }
            else
            {
                cha.ImageNum = choCount++;
            }
        }

        foreach (Sang sang in FindObjectsOfType<Sang>())    // Sang
        {
            if (sang.WhosPiece.Equals("Han"))
            {
                sang.ImageNum = hanCount++;
            }
            else
            {
                sang.ImageNum = choCount++;
            }
        }

        foreach (Ma ma in FindObjectsOfType<Ma>())  // Ma
        {
            if (ma.WhosPiece.Equals("Han"))
            {
                ma.ImageNum = hanCount++;
            }
            else
            {
                ma.ImageNum = choCount++;
            }
        }

        foreach (Po po in FindObjectsOfType<Po>())  // Po
        {
            if (po.WhosPiece.Equals("Han"))
            {
                po.ImageNum = hanCount++;
            }
            else
            {
                po.ImageNum = choCount++;
            }
        }

        foreach (Sa sa in FindObjectsOfType<Sa>())  // Sa
        {
            if (sa.WhosPiece.Equals("Han"))
            {
                sa.ImageNum = hanCount++;
            }
            else
            {
                sa.ImageNum = choCount++;
            }
        }

        foreach (Jol jol in FindObjectsOfType<Jol>())  // Jol
        {
            if (jol.WhosPiece.Equals("Han"))
            {
                jol.ImageNum = hanCount++;
            }
            else
            {
                jol.ImageNum = choCount++;
            }
        }
    }

    public void SetHanKill(int num)
    {
        hanImage[num].color = Color.HSVToRGB(0, 0, 1);
    }

    public void SetChoKill(int num)
    {
        choImage[num].color = Color.HSVToRGB(0, 0, 1);
    }
}

