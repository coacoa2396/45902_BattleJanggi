using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 제작 : 찬규
/// FPS차의 스킬 컴포넌트
/// </summary>
public class FPSChaSkill : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ChaSkillBullet chaSkillBullet;
    [SerializeField] AudioSource sound;

    bool coolTimeCheck;

    private void Start()
    {
        coolTimeCheck = false;
    }

    public void OnSkill(InputValue value)
    {
        if (!coolTimeCheck)
        {
            StartCoroutine(SoundSync());
            sound.Play();
            StartCoroutine(CoolTimeCheck());
        }
    }

    IEnumerator SoundSync()
    {
        yield return new WaitForSeconds(1.1f);
        Instantiate(chaSkillBullet, muzzlePoint.position, muzzlePoint.rotation);
    }

    IEnumerator CoolTimeCheck()
    {
        coolTimeCheck = true;
        yield return new WaitForSeconds(30f);
        coolTimeCheck = false;
    }
}
