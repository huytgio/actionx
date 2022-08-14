using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    
    public enum PickupObject {SOUL};
    public PickupObject currentObject;
    public int pickupQuanlity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        if (other.tag == "Player")
        {
            if(currentObject == PickupObject.SOUL)
            {
                PlayerStat.playerstats.addSoul(this);
                Destroy(gameObject);
            }
            
        }
    }
}
