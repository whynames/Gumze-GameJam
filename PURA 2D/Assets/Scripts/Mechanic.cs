using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mechanic
{
    public bool isActive { get; set; }
    protected GameObject gumVisual;


    protected Rigidbody2D rb;
    public Mechanic(Rigidbody2D rb, GameObject gumVisual)
    {
        this.rb = rb;
        this.gumVisual = gumVisual;
    }


    // Start is called before the first frame update
    public abstract void Execute();

    public virtual void DeActivate()
    {
        isActive = false;
    }
    public virtual void Activate()
    {
        isActive = true;
    }

}
