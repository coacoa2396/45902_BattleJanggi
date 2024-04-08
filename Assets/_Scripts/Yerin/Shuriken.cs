using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Bullet
{
    Coroutine destroy;

    public void Shoot(Vector3 dir)
    {
        ShurikenInit shuri = Weapon.GetComponent<ShurikenInit>();
        Rigid.AddForce(dir * Speed * shuri.BowPower());
    }

    IEnumerator arrowDestroy()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
