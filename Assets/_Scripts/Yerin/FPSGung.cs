using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(궁) 관련 클래스 
/// 장기말의 기능은 부모 클래스에, 여긴 궁의 스킬
/// </summary>
public class FPSGung : FPSPiece
{
    [SerializeField] GungSkill gungSkill;
    [SerializeField] GameObject shield;

    [SerializeField] int existSa;           // 남아있는 사의 개수만큼 피격무시 방어막 생성

    public int ExistSa { get { return existSa; } set { existSa = value; if (existSa == 0) shield.SetActive(false); } }

    Coroutine skill;

    private void Start()
    {
        WallSa[] cats = FindObjectsOfType<WallSa>();
        if (cats != null && cats.Length > 0)
        {
            ExistSa = cats.Length;
        }
        else
        {
            ExistSa = 0;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (ExistSa > 0)
        {
            ExistSa--;
        }
        else
        {
            base.TakeDamage(damage);
        }
    }

    IEnumerator Skill()
    {
        gungSkill.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        CanUseSkill = true;
        gungSkill.gameObject.SetActive(false);
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            skill = StartCoroutine(Skill());
        }
    }
}
