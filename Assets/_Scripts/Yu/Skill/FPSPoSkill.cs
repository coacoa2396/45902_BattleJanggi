using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 개발자: 찬규
/// 
/// 장기말(포) 관련 클래스 
/// 장기말의 기능은 FPSPiece에, 여긴 포의 스킬
/// </summary>
public class FPSPoSkill : MonoBehaviour
{
    [SerializeField] LayerMask wallCheck;
    [SerializeField] CinemachineVirtualCamera skyCam;
    [SerializeField] ParticleSystem atomicBomb;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerInput skillInput;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] FPSControllerBinder binder;

    [SerializeField] float speed;
    [SerializeField] float damage;

    Vector3 moveDir;

    bool isUsing;   // 스킬 사용중 체크
    bool coolTimeCheck;
    float maxDistance = 500;

    private void Start()
    {
        isUsing = false;
        coolTimeCheck = false;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDir * speed * Time.fixedDeltaTime);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    public void OnSkill(InputValue value)
    {
        if (!coolTimeCheck)
        {
            if (!isUsing)
            {
                skyCam.Priority = 50;
                isUsing = true;
                playerInput.enabled = false;
                skillInput.enabled = true;
            }
            else
            {
                Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
                int layerMask = 1 << LayerMask.NameToLayer("Ground");
                if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask))
                {
                    Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.5f);
                    Instantiate(atomicBomb, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Debug.Log("damageSetting");
                    atomicBomb.GetComponent<PoSkillImpact>().SetDamage(damage);
                }
                else
                {
                    Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
                }
                skillInput.enabled = false;
                playerInput.enabled = true;
                isUsing = false;
                skyCam.Priority = 1;
                StartCoroutine(CoolTimeCheck());
                transform.position = playerInput.gameObject.transform.position;
               
                if (gameObject.layer == LayerMask.NameToLayer("Han"))   // 1P  
                {
                    binder.SetGamepad0();
                }
                else
                {
                    binder.SetGamepad1();
                }
            }
        }
    }

    IEnumerator CoolTimeCheck()
    {
        coolTimeCheck = true;
        yield return new WaitForSeconds(30f);
        coolTimeCheck = false;
    }
}
