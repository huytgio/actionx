using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectileE : MonoBehaviour
{
    public float damage;
    public GameObject HitEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);
        if (collision.tag != "Enemy" && collision.name != "E_spell(Clone)")
        {
            if (collision.tag == "Player")
            {
                PlayerStat.playerstats.DealDamage(damage);
            }
            else if (collision.tag == "Environment")
            {
                GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.2f);

            }

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
