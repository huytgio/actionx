using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float CheckRadius;
    public float AttackRadius;

    public bool shouldRotate;
    public LayerMask whatisPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator ani;
    private Vector2 movement;
    public Vector3 dir;

    private float cooldown;
    public float startshoot;
    public GameObject projectile;
    public GameObject HitEffect;
   
    public float Damage;
    
    public float projectileForge;
   

    private bool isInChaseRange;
    private bool isInattckRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        cooldown = startshoot;
        
    }
    private void Update()
    {
        ani.SetBool("Isrunning",isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, CheckRadius,whatisPlayer);
        isInattckRange = Physics2D.OverlapCircle(transform.position, AttackRadius, whatisPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            ani.SetFloat("x", dir.x);
            ani.SetFloat("y", dir.y);
        }

        
    }
    private void FixedUpdate()
    {
        if (isInChaseRange && !isInattckRange)
        {
            MoveCharacter(movement);
        }
        if (isInattckRange)
        {
            
            rb.velocity = Vector2.zero;
            if (cooldown <= 0)
            {
                target = GameObject.FindWithTag("Player").transform;
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 myPos = transform.position;
                Vector2 targetPos = target.transform.position;
                Vector2 dir = (targetPos - myPos).normalized;

                float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - angle));

                spell.GetComponent<Rigidbody2D>().velocity = dir * projectileForge;
                spell.GetComponent<TestProjectileE>().damage = Damage;
                cooldown = startshoot;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }



        }
    }
    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir*speed*Time.deltaTime));
    }
    

}
