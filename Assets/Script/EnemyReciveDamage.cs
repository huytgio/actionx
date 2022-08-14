using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReciveDamage : MonoBehaviour
{
    public float Health;
    public float Maxhealth;

    public GameObject healthbar;
    public Slider healthbarslider;
    public GameObject BloodEffect;
    public GameObject LootDrop;



    void Start()
    {
        Health = Maxhealth;
    }

    public void DealDamage(float damage)
    {
        healthbar.SetActive(true);
        Health -= damage;
        CheckDeath();
        healthbarslider.value = calculatepercentage();
        
    }

    public void CheckOverHealth()
    {
        if (Health > Maxhealth)
        {
            Health = Maxhealth;

        }

    }

    public void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            GameObject Blood = Instantiate(BloodEffect, transform.position, Quaternion.identity);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
            Destroy(Blood, 0.3f);

        }
    }
    private float calculatepercentage()
    {
        return (Health / Maxhealth);
    }
}
