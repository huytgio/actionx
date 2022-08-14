using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator ani;
    public float movespeed;
    public float x, y;
    private bool IsWalking;

    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if(x!=0 || y!=0)
        {
            ani.SetFloat("x", x);
            ani.SetFloat("y", y);
            if (!IsWalking)
            {
                IsWalking = true;
                ani.SetBool("IsMoving", IsWalking);
            }
        }
        else
        {
            if (IsWalking)
            {
                IsWalking = false;
                ani.SetBool("IsMoving", IsWalking);
                StopMoving();
            }
        }
        moveDir = new Vector3(x, y).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir * movespeed * Time.deltaTime;
    }
    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
}
