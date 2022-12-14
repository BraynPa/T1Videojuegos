using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMove : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rb;
    private float Horizontal;
    private bool Grounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }
        else Grounded = false;

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

    }
    
    private void Jump(){
        rb.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal, rb.velocity.y);
    }   
}
