using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShootingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject HitEffect;
    public GameObject player;
    public float minDamage;
    public float maxDamage;
    public float projectileForge;
    public float cooldown;

    private void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        if (player != null)
        {
            yield return new WaitForSeconds(cooldown);
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 dir = (targetPos - myPos).normalized;

            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            spell.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - angle));

            spell.GetComponent<Rigidbody2D>().velocity = dir * projectileForge;
            spell.GetComponent<TestProjectileE>().damage = Random.Range(minDamage, maxDamage);

            StartCoroutine(ShootPlayer());
        }
    }
}
