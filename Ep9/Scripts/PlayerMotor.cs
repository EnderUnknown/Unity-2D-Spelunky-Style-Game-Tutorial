using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : PlayerController
{
    public int playerSpeed;
    public int playerJumpHeight;
    public Animator anim;
    public Transform sprites;
    public LayerMask exitDoorMask;

    private bool facingRight = true;

    void Start()
    {
        anim = sprites.GetComponent<Animator>();
    }

    void Update()
    {
        UpdatePlayer();
    }
    void UpdatePlayer()
    {
        float pSpeed = Input.GetAxis("Horizontal");

        Vector2 move = Vector2.zero;

        if (!crouched && !Input.GetKey(KeyCode.LeftControl))
            move.x = Input.GetAxis("Horizontal");
        else if (!crouched && Input.GetKey(KeyCode.LeftControl))
            move.x = Input.GetAxis("Horizontal") * 2;
        if (Input.GetButton("Jump") && grounded)
        {
            anim.SetTrigger("onJump");
            if (Mathf.Abs(velocity.x) > 0)
            {
                velocity.y = playerJumpHeight + Mathf.Abs(velocity.x * 0.2f);
            }
            else
            {
                velocity.y = playerJumpHeight;
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }
        else
        {
            crouched = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Collider2D doorCheck = Physics2D.OverlapCircle(transform.position, 0.1f, exitDoorMask);
            if(doorCheck != null)
            {
                Generation.NextLevel();
                doorCheck.GetComponent<ExitDoor>().NextLevel();
            }
        }

        if(grounded)
            anim.SetBool("isGrounded", true);
        else
            anim.SetBool("isGrounded", false);

        if (move.x > 0)
            facingRight = false;
        else if(move.x < 0)
            facingRight = true;

        if (facingRight)
            sprites.rotation = Quaternion.Euler(Vector3.up * 180);
        else
            sprites.rotation = Quaternion.Euler(Vector3.zero);

        if (move.x == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        targetVelocity = move * playerSpeed;
    }

    public void OnDeath()
    {
        Debug.Log("The Player Has Died.");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMotor>())
            return;
        else if (col.gameObject.GetComponent<Treasure>())
            col.gameObject.GetComponent<Treasure>().OnCollide(true);
        else if (col.gameObject.GetComponent<EnemyBase>())
            TakeDamage(col.GetComponent<EnemyBase>().colDamage);
    }

    public void TakeDamage(int amount)
    {
        GetComponent<LivingBase>().Damage(amount);
    }
    public void TakeDamage(int amount, Vector2 targetPos)
    {
        TakeDamage(amount);
        velocity += new Vector2((targetPos.x >= transform.position.x) ? -20 : 20, (targetPos.y >= transform.position.y) ? -20 : 20);
    }
}
