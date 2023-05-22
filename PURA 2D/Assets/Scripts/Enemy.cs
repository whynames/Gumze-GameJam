using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour, IAbsorbable
{


    Rigidbody2D rb;

    Animator animator;

    CharacterManager character;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletPosition;

    [SerializeField]
    float size;

    float shootTimer = 0;
    public float Size { get => size; set => size = value; }

    bool canShoot;
    private void Start()
    {
        canShoot = true;
        character = CharacterManager.Instance;
        rb = bulletPrefab.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void ShootAt(Transform transformToShoot)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 aim = character.transform.position - transform.position;
        rb.AddForce(aim);
        animator.SetTrigger("attack");
    }
    public void AddToBubble(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        canShoot = false;
    }

    public void DestroyBubble()
    {
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            float distance = Vector2.Distance(character.transform.position, transform.position);
            if ((distance < 8) && (shootTimer > 3))
            {
                shootTimer = 0;
                ShootAt(character.transform);
            }
        }
    }
}
