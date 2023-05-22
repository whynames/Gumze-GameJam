using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMechanic : Mechanic
{



    float flyingPower;

    public FlyingMechanic(Rigidbody2D rb, GameObject gumVisual, float flyingPower) : base(rb, gumVisual)
    {
        this.flyingPower = flyingPower;
    }

    public override void Activate()
    {
        base.Activate();
    }
    public override void Execute()
    {
        if (isActive)
        {
            Vector3 scale = gumVisual.transform.localScale;
            float t = Time.deltaTime;
            flyingPower += t * 15;
            flyingPower *= Mathf.Clamp01(scale.x);
            flyingPower = Mathf.Clamp(flyingPower, 0, 5);
            float floatScale = Mathf.Clamp(scale.x + t, 0, 3);
            gumVisual.transform.localScale = new Vector3(floatScale, floatScale, floatScale);
            CharacterManager.Instance.movement.MoveCharacter(Vector2.up, flyingPower);
        }

    }

    public void StopBlowing()
    {
        if (isActive)
        {
            float t = Time.deltaTime;

            Vector3 scale = gumVisual.transform.localScale;
            if (scale.x > (Vector3.one / 100).x)
            {
                flyingPower -= t * 5;
                flyingPower *= Mathf.Clamp01(scale.x);
                gumVisual.transform.localScale = scale - Vector3.one * t;
            }
        }

    }

}
