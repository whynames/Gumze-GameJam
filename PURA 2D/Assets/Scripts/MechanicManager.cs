using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicManager : MonoSingleton<MechanicManager>
{

    [field: SerializeField]
    public List<GumBubble> gumBubbles { get; private set; }

    GumBubble currentGumBubble;

    [field: SerializeField] public GameObject character { get; private set; }

    bool isGumBubbleSet;

    public void SetCurrentGumBubble()
    {
        if (gumBubbles.Count > 0)
        {
            currentGumBubble = gumBubbles[0];
            currentGumBubble.Begin();
        }
        else
        {
            currentGumBubble = null;
        }
    }
    public void ChangeCurrentGumBubble()
    {
        gumBubbles.RemoveAt(0);
        SetCurrentGumBubble();
    }
    private void Start()
    {
        SetCurrentGumBubble();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (currentGumBubble)
        {
            currentGumBubble.LogicUpdate();
        }
    }
}
