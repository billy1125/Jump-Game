using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Animator animator;

    public float jumpForce = 400.0f;
    public float walkForce = 10.0f;
    public float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpTrigger");
            rigid2d.AddForce(transform.up * jumpForce);
            //rigid2d.AddForce(new Vector3(0, 1, 0) * jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;        
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(rigid2d.velocity.x);

        if (speedx < maxWalkSpeed)
            rigid2d.AddForce(transform.right * key * walkForce);

        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        if (rigid2d.velocity.y == 0)
            animator.speed = speedx / 2;
        else
            animator.speed = 1;
    }
}
