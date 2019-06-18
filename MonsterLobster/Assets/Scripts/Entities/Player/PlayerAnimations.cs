using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator = null;
    public static PlayerAnimations Call = null;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Call = this;
    }

    public void setWalkingAnimation(bool active)
    {
        if (active)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);
    }

    public void SetDashAnimation(bool active)
    {
        if (active)
            animator.SetBool("dash", true);
        else
            animator.SetBool("dash", false);
    }

    public void SetImpactAnimation(bool active)
    {
        if (active)
            animator.SetBool("impact", true);
        else
            animator.SetBool("impact", false);
    }

    public void SetDieAnimation(bool active)
    {
        if (active)
            animator.SetBool("die", true);
        else
            animator.SetBool("die", false);
    }

    public void SetFinishAnimation(bool active)
    {
        if (active)
            animator.SetBool("finish", true);
        else
            animator.SetBool("finish", false);
    }

}
