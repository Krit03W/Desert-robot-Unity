using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Idle_Controller : MonoBehaviour
{
    public float speed;
    int jump;
    float x, sx;
    bool ks;
    Animator am;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sx = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        am.SetFloat("speed", Abs(x));
        if (Input.GetButtonDown("Jump") && jump <4)

        if (Input.GetButtonDown("Jump"))
        {
                jump++;
            am.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if (x > 0)
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        am.SetBool("jump", false);
        jump = 0;

    }
    float Abs(float x)
    {
        return x >= 0f ? x : -x;
    }
}