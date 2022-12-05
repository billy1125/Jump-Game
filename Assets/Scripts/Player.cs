using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2d;
    float jumpForce = 300.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2d.AddForce(transform.up * jumpForce);
            //rigid2d.AddForce(new Vector3(0, 1, 0) * jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;        
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(rigid2d.velocity.x);

        if (speedx < maxWalkSpeed)
            rigid2d.AddForce(transform.right * key * walkForce);
    }
}
