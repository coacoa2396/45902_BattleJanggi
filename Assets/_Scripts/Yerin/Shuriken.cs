using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Weapon
{
    float value;
    Vector3 lookPos;
    [SerializeField] float speed;

    /// <summary>
    /// 흠...
    /// </summary>
    /// <param name="_value">나라갈 수 있는 거리</param>
    /// <param name="dir"> 공격 방향</param>
    public void SetValue(float _value, Vector3 dir)
    {
        value = _value;
        lookPos = dir;
        MoveCo = StartCoroutine(MoveRoutine());
    }
    Coroutine MoveCo;

    IEnumerator MoveRoutine()
    {
        Vector3 desPos = lookPos * value; //거리 계산(상대좌표)

        Vector3 absolueDesPos = desPos +transform.position; //절대좌표 도착지점
        Vector3 currentPos = transform.position;                //절대좌표출발지

        Vector3 moveSpeed = (currentPos - absolueDesPos).normalized * speed; //이동속도

        float destLength = Vector3.Distance(currentPos, absolueDesPos); //도착지까지의 거리
        float moveLength = 0;                                            //이동 거리

        while (destLength >= moveLength)                    //도착지 거리를 넘었는지 확인
        {
            transform.Translate(moveSpeed); //이동
            moveLength += speed;        //총 이동 거리
            yield return null;
        }
        StopCo();
    }

    private void OnTriggerEnter(Collider other) => OnDamage(other);
    private void OnCollisionEnter(Collision collision) => OnDamage(collision.collider);

    void OnDamage(Collider target)
    {
        Piece targetCom = target.GetComponent<Piece>();
        if (targetCom == null)
            return;
        if(targetCom.WhosPiece.Equals("적"))
        {
            StopCo();
        }
        Debug.LogError("상대를 판별 불가! 조건식 수정 요망");
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
    /// 풀링을 요청합니다.
    /// 하지만, 아닐 경우를 대비하여 파괴를 합니다.
    /// </summary>
    void StopCo()
    {
        if (MoveCo != null)
            StopCoroutine(MoveCo);
        Destroy(gameObject);
    }
}
