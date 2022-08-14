using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToplayer : MonoBehaviour
{
    public float speed;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.fixedDeltaTime);
        }
        
    }
}
