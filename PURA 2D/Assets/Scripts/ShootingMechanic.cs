using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : Mechanic
{
    float shootingPower;

    public float aliveTime { get; private set; }
    public ShootingMechanic(Rigidbody2D rb, GameObject gumVisual, float shootingPower) : base(rb, gumVisual)
    {
        this.shootingPower = shootingPower;
        aliveTime = 0;
    }

    public override void Execute()
    {
        isActive = true;
        Rigidbody2D rb2 = gumVisual.GetComponent<Rigidbody2D>();
        Debug.Log(InputManager.Instance.clickPosition);
        rb2.AddForce((InputManager.Instance.clickPosition - new Vector2(CharacterManager.Instance.transform.position.x, CharacterManager.Instance.transform.position.y)) * shootingPower);
        gumVisual.transform.SetParent(null);
        MechanicManager.Instance.ChangeCurrentGumBubble();

    }

    public void IncreaseTimer()
    {
        aliveTime += Time.deltaTime;
    }
    // Start is called before the first frame update
}
