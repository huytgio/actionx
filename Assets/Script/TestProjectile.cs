using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;
    public GameObject HitEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name != "Player" && collision.name != "Test Spell(Clone)")
        {
            if (collision.GetComponent<EnemyReciveDamage>() != null)
            {
                collision.GetComponent<EnemyReciveDamage>().DealDamage(damage);
                
            }
            else if(collision.tag == "Environment")
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
