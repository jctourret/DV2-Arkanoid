using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 3;
    public int speed = 200;
    bool isMovingLeft;
    bool isMovingRight;
    Vector3 direction;
    Rigidbody rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        direction = transform.forward;    
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isMovingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isMovingLeft = true;
        }
    }
    private void FixedUpdate()
    {
        if (isMovingRight)
        {
            rg.velocity = direction * speed * Time.deltaTime;
            isMovingRight = false;
        }
        else if (isMovingLeft)
        {
            rg.velocity = -direction * speed * Time.deltaTime;
            isMovingLeft = false;
        }
        else
        {
            rg.velocity = new Vector3(0,0,0);
        }
    }
}
