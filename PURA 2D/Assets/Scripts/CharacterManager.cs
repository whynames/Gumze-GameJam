using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleton<CharacterManager>
{
    [SerializeField]
    private float speed;

    public float health { get; set; }

    [field: SerializeField]
    public Movement movement { get; private set; }

    public CoinCollection coinCollection { get; private set; }

    internal void AddToCollection(CoinCollection coinCollection, Coin item)
    {
        coinCollection.collection.Add(item);
        Debug.Log(coinCollection.collection.Count);
    }

    private void Start()
    {
        coinCollection = new CoinCollection();
    }

    private void Update()
    {
        if (InputManager.Instance.moving)
        {
            movement.MoveCharacter(InputManager.Instance.movingPosition * Time.deltaTime * speed);
        }
    }

}
