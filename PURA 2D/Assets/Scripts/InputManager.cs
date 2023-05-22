using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    Camera cam;
    public bool mouseClicked { get; private set; }
    public bool moving { get; private set; }
    public bool flying { get; private set; }
    public bool needleOpened { get; private set; }


    public Vector2 movingPosition { get; private set; }

    public Vector2 clickPosition { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        mouseClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseClicked = true;
            AnimationManager.Instance.SetTrigger();

        }
        else
        {
            clickPosition = Vector2.zero;
            mouseClicked = false;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            movingPosition = new Vector2(Input.GetAxis("Horizontal"), 0);
            moving = true;
            AnimationManager.Instance.SetSpeed(movingPosition.x);
        }
        else
        {
            movingPosition = Vector2.zero;
            AnimationManager.Instance.SetSpeed(movingPosition.x);
            moving = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            flying = true;
            AnimationManager.Instance.SetBool(flying);

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            flying = false;
            AnimationManager.Instance.SetBool(flying);
        }
    }
}
