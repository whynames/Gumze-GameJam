using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Danger, IAbsorbable
{
    protected Animator anim;
    protected Rigidbody2D rb;

    protected int facingDirection = -1;

    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected LayerMask whatToIgnore;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected Transform wallCheck;
    protected bool wallDetected;
    protected bool groundDetected;
    protected RaycastHit2D playerDetection;

    protected Transform player;
    [HideInInspector] public bool invincible;
    [SerializeField] protected float raycastDistance = 100f; // I��n uzunlu�u
    [SerializeField] protected float raycastStep = 1f; // I��n ad�m�


    [Header("Move info")]
    [SerializeField] protected float speed;
    [SerializeField] protected float idleTime = 2;
    protected float idleTimeCounter;


    protected bool canMove = true;
    protected bool aggresive;
    [SerializeField]

    float size;
    public float Size { get => size; set => size = value; }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
            groundCheck = transform;
        if (wallCheck == null)
            wallCheck = transform;
    }


    protected virtual void WalkAround()
    {
        if (idleTimeCounter <= 0 && canMove)
            rb.velocity = new Vector2(speed * facingDirection, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        idleTimeCounter -= Time.deltaTime;


        if (wallDetected || !groundDetected)
        {
            idleTimeCounter = idleTime;
            Flip();
        }
    }


    public void DestroyMe()
    {

        Destroy(gameObject);
    }


    protected virtual void Flip()
    {
        facingDirection = facingDirection * -1;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void CollisionChecks()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
        playerDetection = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, 100, ~whatToIgnore);
    }

    protected virtual void OnDrawGizmos()
    {
        if (groundCheck != null)
            Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));

        if (wallCheck != null)
        {
            Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y));
            Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + playerDetection.distance * facingDirection, wallCheck.position.y));
        }

    }

    public void AddToBubble(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }

    public void DestroyBubble()
    {

    }
}