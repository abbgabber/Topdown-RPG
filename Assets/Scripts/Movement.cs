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
    public int dashSpeed = 250000;
    public bool dash = true;
    public int dashCD = 80;
    public GameObject dashEffect;



    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (movement.x == -1)
        {
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        if (dashCD == 0)
        {
            dash = true;
        }
        else
        {
            dashCD--;
        }

        if (movement.sqrMagnitude != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && dash)
            {
                rb.AddForce(movement * dashSpeed * Time.fixedDeltaTime);
                dash = false;
                dashCD = 80;

                // GameObject effect = Instantiate(dashEffect, transform.position, transform.rotation);
                // // Rigidbody2D dashRb = effect.GetComponent<Rigidbody2D>();
                // // dashRb.AddForce(movement * dashSpeed * Time.fixedDeltaTime);
                // Destroy(effect, 60f);
                {
                    GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 0.5f);

                }
            }
        }
    }
}
