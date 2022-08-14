using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public float Health;
    public float Maxhealth;
    public GameObject player;
    public Image[] Heart;
    public static PlayerStat playerstats;
    public int souls;
    public Text soulValue;

    public Sprite Full;
    public Sprite Haft;
    public Sprite Empty;

    void Awake()
    {
        if (playerstats != null)
        {
            Destroy(playerstats);
        }
        else { playerstats = this; }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Health = Maxhealth;


    }

    public void DealDamage(float damage)
    {
        Health -= damage;

        CheckDeath();
    }
    public void heathchar(float heal)
    {
        Health += heal;
        CheckOverHealth();
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

        }
    }
    private void Update()
    {


        for (int i = 0; i < Heart.Length*20; i=i+20)
        {
            
            if (i < Health)
            {
                if (i + 10 < Health)
                {
                    Heart[i/20].sprite = Full;

                }
                else
                {
                    Heart[i /20].sprite = Haft;

                }
            }
            else
            {
                Heart[i/20].sprite = Empty;
                
            }

        }

    }
    public void addSoul(ItemPickup soul)
    {
        if(soul.currentObject == ItemPickup.PickupObject.SOUL)
        {
            souls += soul.pickupQuanlity;
            soulValue.text = "Soul X" + souls.ToString();
        }
    }
    public void addHeart(ItemPickup heart)
    {
        if (heart.currentObject == ItemPickup.PickupObject.HEART)
        {
            Health += heart.pickupQuanlity;
            CheckOverHealth();
        }
    }
}
