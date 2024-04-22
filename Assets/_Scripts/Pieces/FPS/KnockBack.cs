using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Á¦ÀÛ : Âù±Ô
/// ³Ë¹é °ü·Ã Å¬·¡½º
/// </summary>
public class KnockBack : MonoBehaviour
{
    [SerializeField] LayerMask knockBackCheck;
    [SerializeField] CharacterController controller;
    [SerializeField] float power;
    [SerializeField] float lerpRate;

    [SerializeField] bool isKnockbacking;
    [SerializeField] float ySpeed;

    private void Update()
    {
        ySpeed += Time.deltaTime * Physics.gravity.y * 4f;
        if (controller.isGrounded)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (knockBackCheck.Contain(collision.gameObject.layer) || collision.gameObject.TryGetComponent(out WallSting sting))
        {
            Debug.Log($"{collision.transform.gameObject.name}¶û ºÎµúÈû");
            if (isKnockbacking == false)
            {
                StartCoroutine(KnockbackRoutine(collision.contacts[0].normal + Vector3.up * 0.5f));
            }
        }
    }

    IEnumerator KnockbackRoutine(Vector3 dir)
    {
        isKnockbacking = true;

        dir *= power;
        float rate = 1;
        while (rate >= 0.1f)
        {
            controller.Move(dir * rate * Time.fixedDeltaTime);

            rate = Mathf.Lerp(rate, 0, lerpRate);
            yield return new WaitForFixedUpdate();
        }
        isKnockbacking = false;
    }
}

