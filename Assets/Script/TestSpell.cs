using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    public GameObject HitEffect;
    public float Damage;
    public float projectileForge;
    

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            Vector2 myPos = transform.position;
            
            Vector2 direction = (mousePos - myPos).normalized;
            /*Vector2 differ = mousePos - myPos*/;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90-angle));
            


            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForge;
            spell.GetComponent<TestProjectile>().damage = Damage;
           

        }
        
    }
    
}
