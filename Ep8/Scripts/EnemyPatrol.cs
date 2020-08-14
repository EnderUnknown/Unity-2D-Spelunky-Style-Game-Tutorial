using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : PlayerController
{
    public float speed;
    public Animator anim;
    public Transform edgeDetector;
    bool movingRight;

    void Start()
    {
        movingRight = Random.Range(0, 2) == 0;
    }

    void Update()
    {
        Vector2 move = Vector2.zero;
        if (movingRight)
        {
            move.x = 1;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            move.x = -1;
            transform.rotation = Quaternion.Euler(Vector3.up * 180);
        }

        RaycastHit2D ray = Physics2D.Raycast(edgeDetector.position, Vector2.down, 1f);
        if (ray.collider == false)// || ray.collider.gameObject.layer == LayerMask.NameToLayer("NoCollision"))
            movingRight = !movingRight;

        if (move.x == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        targetVelocity = move * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Default"))
            movingRight = !movingRight;
    }
}
