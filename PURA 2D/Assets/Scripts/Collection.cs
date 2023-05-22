using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collection<T>
{
    public HashSet<T> collection = new HashSet<T>();
    public int count { get { return collection.Count; } }
}
