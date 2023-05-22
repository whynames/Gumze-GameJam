using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoSingleton<AnimationManager>
{
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update

    public void SetSpeed(float value)
    {
        animator.SetFloat("speed", Mathf.Abs(value));
    }
    public void SetBool(bool value)
    {
        animator.SetBool("flying", value);
    }
    public void SetTrigger()
    {
        animator.SetTrigger("shootingAnimation");
    }
}
