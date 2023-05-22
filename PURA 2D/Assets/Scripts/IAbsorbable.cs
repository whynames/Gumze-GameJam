using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbsorbable
{
    public void AddToBubble(Transform parent);

    public void DestroyBubble();
    float Size { get; set; }
}

