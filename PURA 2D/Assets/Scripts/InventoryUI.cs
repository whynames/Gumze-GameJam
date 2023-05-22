using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoSingleton<InventoryUI>
{

    [SerializeField]
    GameObject gum;
    int count;
    [SerializeField]
    SpriteRenderer inventoryUI;
    // Start is called before the first frame update
    public void Refresh()
    {
        count = transform.childCount;
        inventoryUI.size = new Vector2(5.12f, 5.12f * count);
    }

    private void Update()
    {
        Refresh();
    }
    public void AddToInventory()
    {
        GameObject gumObj = Instantiate(gum, Vector3.zero, Quaternion.identity, this.transform);
        gumObj.transform.localPosition = Vector3.zero;
        MechanicManager.Instance.gumBubbles.Add(gumObj.GetComponent<GumBubble>());
    }
}
