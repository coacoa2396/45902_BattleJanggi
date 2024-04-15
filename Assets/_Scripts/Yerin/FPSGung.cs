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

    [SerializeField] bool canDamaged = true;

    public int ExistSa { get { return existSa; } set { existSa = value; if (existSa == 0) shield.SetActive(false); } }

    public bool CanDamaged { get {  return canDamaged; } set { canDamaged = value; } }

    Coroutine skill;

    private void Start()
    {
        // 한나라의 궁일때
        if (gameObject.layer == LayerMask.NameToLayer("Han"))
        {
            ExistSa = Manager.JanggiTurn.HanSa;
        }
        // 초나라의 궁일 때
        else
        {
            ExistSa = Manager.JanggiTurn.ChoSa;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (!canDamaged) 
        {
            return;
        }

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

    protected override void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            skill = StartCoroutine(Skill());
            base.OnSkill(value);
        }
    }
}
