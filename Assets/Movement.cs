using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject player;

    public Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    
    void FixedUpdate(){
        if(movement.x == -1){
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        } else{
             player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
