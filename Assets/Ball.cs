using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed;
    public float moveForce;
    public float jumpSpeed;
    Rigidbody2D rb;
    bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor,0) * moveForce * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }
        LimitSpeed();
    }

    void LimitSpeed()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 0;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Win();
        //print("Touch");
        //WinS.clip = WinC;
        //WinS.Play();
    }
}
