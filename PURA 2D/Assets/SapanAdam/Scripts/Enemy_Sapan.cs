using UnityEngine;

public class Enemy_Sapan : Enemy2
{

    [Header("Collision Ozellik")]
    [SerializeField] private LayerMask whatIsPlayer; // Oyuncunun katmanı
    [SerializeField] private Transform groundBehindCheck; // Arkadan zemin kontrolü için kullanılan nokta
    private bool wallBehind; // Arkasında duvar var mı
    private bool groundBehind; // Arkasında zemin var mı
    private GameObject oyuncu; // Oyuncu nesnesi referansı
    private float timer; // Zamanlayıcı


    [Header("Mermi Ozellik")]
    [SerializeField] private GameObject bulletPrefab; // Mermi prefabı
    [SerializeField] private Transform bulletOrigin; // Mermi çıkış noktası

    protected override void Start()
    {
        base.Start();

        oyuncu = GameObject.FindGameObjectWithTag("Player"); // "Player" etiketine sahip nesneyi bul ve referansını al
    }


    void Update()
    {
        CollisionChecks();
        anim.SetFloat("xVelocity", rb.velocity.x);

        if (!canMove)
            rb.velocity = new Vector2(0, 0);


        float distance = Vector2.Distance(transform.position, oyuncu.transform.position);

        Vector2 enemyX = oyuncu.transform.position - transform.position;


        if (enemyX.x > 0)
        {
            Debug.Log("Sağımda");
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            Debug.Log("Solumda");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (distance < 17)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                anim.SetTrigger("attack");
                canMove = false;
            }
        }
        else
        {
            WalkAround();
        }

    }

    private void MoveBackwards(float multiplier)
    {
        if (wallBehind)
            return;
        if (!groundBehind)
            return;
        rb.velocity = new Vector2(speed * multiplier * -facingDirection, rb.velocity.y);
    }

    private void AttackEvent()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
    }


    private void ReturnMovement()
    {
        canMove = true;
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();

        groundBehind = Physics2D.Raycast(groundBehindCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallBehind = Physics2D.Raycast(wallCheck.position, Vector2.right * (-facingDirection + 1), wallCheckDistance, whatIsGround);

    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(groundBehindCheck.position,
            new Vector2(groundBehindCheck.position.x, groundBehindCheck.position.y - groundCheckDistance));
    }
}
