using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumBubble : MonoBehaviour
{
    // Start is called before the first frame update
    [field: SerializeField]
    public FlyingMechanic flyingMechanic { get; private set; }
    [field: SerializeField]
    public ShootingMechanic shootingMechanic { get; private set; }

    [field: SerializeField] public GameObject character { get; private set; }

    bool isGumBubbleSet;

    float aliveTime;

    Rigidbody2D rb;

    [SerializeField]
    CircleCollider2D cc2d;

    [SerializeField]
    float flyingPower;
    [SerializeField]
    private float shootingPower;

    [HideInInspector]
    public float size;

    [SerializeField]
    HashSet<IAbsorbable> absorbedOnes;

    [SerializeField]
    GameObject gumBubbleVisual;

    public void Begin()
    {
        absorbedOnes = new HashSet<IAbsorbable>();
        flyingMechanic = new FlyingMechanic(rb, this.gameObject, flyingPower);
        shootingMechanic = new ShootingMechanic(rb, this.gameObject, shootingPower);
        rb = GetComponent<Rigidbody2D>();
        flyingMechanic.Activate();
        shootingMechanic.DeActivate();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    public void LogicUpdate()
    {
        size = transform.localScale.x;
        if (InputManager.Instance.mouseClicked)
        {
            flyingMechanic.DeActivate();
            rb.isKinematic = false;
            cc2d.enabled = true;
            shootingMechanic.Activate();
            shootingMechanic.Execute();

        }
        else if (InputManager.Instance.flying)
        {
            flyingMechanic.Execute();
        }
        else
        {
            flyingMechanic.StopBlowing();
        }


    }

    private void Update()
    {
        if (shootingMechanic != null)
        {
            if (shootingMechanic.isActive)
            {
                shootingMechanic.IncreaseTimer();
            }
        }
    }
    public void DestroyBubble()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.pop);
        foreach (var item in absorbedOnes)
        {
            Type type = item.GetType();
            item.DestroyBubble();
            if (type == typeof(Coin))
            {
                Coin myBObject = item as Coin;
                Destroy(myBObject);
            }
        }
        Destroy(this.gameObject);
    }

    public void HitEnemy()
    {

    }
    public void CollectCoin()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IAbsorbable>(out var absorbable) && absorbedOnes != null)
        {
            if (size > absorbable.Size)
            {
                absorbedOnes.Add(absorbable);
                absorbable.AddToBubble(gumBubbleVisual.transform);
                if (other.CompareTag("Coin"))
                {
                    CollectCoin();
                }
                else if (other.CompareTag("Enemy"))
                {
                    HitEnemy();
                }
            }
        }
        if (shootingMechanic != null)
        {
            /*  if (other.CompareTag("Player") && shootingMechanic.aliveTime > 0.1f)
             {
                 Debug.Log("collisionPlayer");
                 DestroyBubble();
                 shootingMechanic.isActive = false;
             } */
        }
    }


}
