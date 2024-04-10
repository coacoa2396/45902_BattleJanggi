using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말(상)의 스킬 물풍선 관련 클래스
/// </summary>
public class WaterBalloon : Bullet
{
    [SerializeField] GameObject slowdownFloor;
    [SerializeField] LayerMask groundCheck;
    public void Shoot(Vector3 dir)
    {
        Rigid.AddForce(dir * Speed * 10);
    }

    IEnumerator SlowDownFloor()
    {
        GameObject floor = Instantiate(slowdownFloor, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(5f);

        Destroy(floor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (groundCheck.Contain(collision.gameObject.layer))
        {
            //Coroutine slowdown = StartCoroutine(SlowDownFloor());
            GameObject floor = Instantiate(slowdownFloor, transform.position, Quaternion.identity);
        }
    }
}
