using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float runSpeed = 4;
    [SerializeField] private LayerMask Ground;

    private Animator anim;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {

                Debug.Log("WHY");
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("flip to right");
                }

                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(-runSpeed, 0);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {

                Debug.Log("not");
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    Debug.Log("flip to left");
                }

                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(runSpeed, 0);
                }
            }
            else
            {
                facingLeft = true;
            }
        }

    }
}
