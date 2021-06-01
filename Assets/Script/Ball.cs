using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Player player;
    Rigidbody rg;
    bool startMoving = false;
    Vector3 direction;
    float startOffsetMulti =1.2f;
    public float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        direction = transform.forward-transform.right;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMoving)
        {
            transform.position = player.transform.position - (transform.right*startOffsetMulti);
        }
        if (Input.GetButtonDown("Jump"))
        {
            startMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (startMoving)
        {
            rg.velocity = direction * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WallR" || collision.collider.tag == "WallL")
        {
            direction = new Vector3(direction.x,direction.y,-direction.z);
        }
        if (collision.collider.tag == "WallT" || collision.collider.tag == "Player")
        {
            direction = new Vector3(-direction.x, direction.y, direction.z);
        }
        if (collision.collider.tag == "WallB")
        {
            startMoving = false;
            player.lives--;
            GameManager.Get().checkEnd(player.lives);
            direction = new Vector3(-direction.x, direction.y, direction.z);
        }
        if (collision.collider.tag == "Box")
        {
            RaycastHit hit;
            Box box = collision.collider.GetComponent<Box>();
            if (Physics.Raycast(transform.position, collision.collider.transform.position - transform.position, out hit) && !box.hasCollided)
            {
                Vector3 localpoint = hit.transform.InverseTransformDirection(hit.point);
                Vector3 localDir = localpoint.normalized;

                float fwdDot = Vector3.Dot(localDir, Vector3.forward);
                float rightDot = Vector3.Dot(localDir, Vector3.right);

                float fwdPower = Mathf.Abs(fwdDot);
                float rightPower = Mathf.Abs(rightDot);

                if (fwdPower > rightPower)
                {
                    direction = new Vector3(direction.x, direction.y, -direction.z);
                }
                else
                {
                    direction = new Vector3(-direction.x, direction.y, direction.z);
                }
                GameManager.Get().score += box.score;
                GameManager.Get().totalBoxes--;
                GameManager.Get().checkEnd(player.lives);
                box.hasCollided = true;
                Destroy(collision.collider.gameObject);
            }
        }
    }
}