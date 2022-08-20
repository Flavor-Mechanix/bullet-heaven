using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float runSpeed = 20.0f;
    public Animator animator;
    public SpriteRenderer sprite;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        body.MovePosition(body.position + Time.deltaTime*(new Vector2(horizontal * runSpeed, vertical * runSpeed)));

        if (horizontal != 0 | vertical != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (horizontal == -1)
        {
            sprite.flipX = true;
        }
        else if (horizontal == 1)
        {
            sprite.flipX = false;
        }
    }

}
