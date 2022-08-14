using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public enum PickupObject {SOUL,HEART};
    public PickupObject currentObject;
    public int pickupQuanlity;
    private Collider2D Item;



    private void Start()
    {
        
    }
    private void Update()
    {
        checkoverheal();
       
    }
    public void checkoverheal()
    {
        Item = GetComponent<Collider2D>();
        if ((PlayerStat.playerstats.Health * PlayerStat.playerstats.Maxhealth) / 100 < 95)
        {
            Item.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
        
        if (other.tag == "Player")
        {
            if(currentObject == PickupObject.SOUL)
            {
                PlayerStat.playerstats.addSoul(this);
                Destroy(gameObject);
            }
            if (currentObject == PickupObject.HEART)
            {
                PlayerStat.playerstats.addHeart(this);
                Destroy(gameObject);
            }
        }

    }
    
}
