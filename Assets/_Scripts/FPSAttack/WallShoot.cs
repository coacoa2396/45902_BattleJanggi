using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개발자: Yerin
/// 
/// 포 벽 위에 있는 활 관련 클래스
/// </summary>
public class WallShoot : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float speed;
    [SerializeField] float power;

    GameObject arrowCopy;
    Coroutine arrowDestroy;

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(2.02f);

        Destroy(arrowCopy);
    }

    public void ShootStart()
    {
        arrowCopy = Instantiate(arrow, arrow.transform.position, arrow.transform.rotation);
        arrowCopy.transform.localScale = new Vector3(5, 5, 5);
        arrow.SetActive(false);

        arrowCopy.GetComponent<Rigidbody>().AddForce(-arrowCopy.transform.up * speed * power);

        arrowDestroy = StartCoroutine(DestroyArrow());
    }

    public void ShootFinish()
    {
        arrow.SetActive(true);
    }
}
