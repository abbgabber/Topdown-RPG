using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 20f;
    public bool shoot = true;
    public float shootCD = 30;


    // Update is called once per frame
    void Update()
    {
        if (shootCD == 0)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }
        }
        else
        {
            shootCD--;
        }

    }

    void Shoot()
    {
        Vector2 movement = gameObject.GetComponent<Movement>().movement;

        if (movement.sqrMagnitude != 0)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

            rb.AddForce(movement * arrowForce, ForceMode2D.Impulse);
            shootCD = 30;
            shoot = false;
        }
    }
}
