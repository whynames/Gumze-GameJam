using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IAbsorbable
{
    public float Size { get => size; set => size = value; }

    [SerializeField]
    private float size;
    public void AddToBubble(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }

    public void DestroyBubble()
    {
        CharacterManager.Instance.AddToCollection(CharacterManager.Instance.coinCollection, this);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryUI.Instance.AddToInventory();
            Destroy(this.gameObject);
        }
    }
}
