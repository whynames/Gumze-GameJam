using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTas : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GumBubble gum = other.gameObject.GetComponent<GumBubble>();
            if (gum.size > 0.5)
            {
                gum.DestroyBubble();
                MechanicManager.Instance.SetCurrentGumBubble();
                Destroy(other);
            }
        }
    }
}
