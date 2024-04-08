using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작자 : ChanGyu
/// 장기말(차)의 레이저건
/// </summary>
public class ChaLazer : Weapon
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LazerGunImpact hitEffect;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] AudioSource sound;

    [SerializeField] Transform hitPoint;

    public override void Fire()
    {
        muzzleFlash.Play();
        sound.Play();

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {

            // 레이캐스트 보이게 하기
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.5f);
            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            // 맞는 위치에 총자국 이펙트
            Manager.Pool.GetPool(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            //ParticleSystem partcl = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            //partcl.transform.position = hitInfo.point;
            //Destroy(partcl, 1.5f);

            // 맞았을 때 물리력 구현
            //Rigidbody rigid = hitInfo.collider.GetComponent<Rigidbody>();
            //if (rigid != null)
            //{
            //    rigid.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
            //}

            // 맞는 로그
            Debug.Log("맞았다!");

            // 인터페이스를 찾아서 데미지 넣기
            FPSPiece target = hitInfo.collider.GetComponent<FPSPiece>();

            target?.TakeDamage(Damage);

            // 레이캐스트 디버깅 방법
            /*
            Debug.Log(hitInfo.collider.gameObject.name);
            Debug.Log(hitInfo.distance);
            hitPoint.position = hitInfo.point;
            */
        }
        else
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1,hitInfo.point + ray.direction * maxDistance);
            Debug.Log("안맞았다!");
        }
    }
}
