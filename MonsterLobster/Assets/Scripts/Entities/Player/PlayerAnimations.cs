using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator = null;
    public static PlayerAnimations Call = null;
    public bool dead = false;
    float timer = 5.0f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Call = this;
    }

    void Update()
    {
        if (dead)
        {
            if (timer < 0.0f)
            {
                SceneManager.LoadScene("Scoreboard Scene");

            }
            timer -= Time.deltaTime;
        }
    }

    public void setIdleAnimation(bool active)
    {
        if (active)
        {
            animator.SetBool("finish", false);
            animator.SetBool("running", false);
            animator.SetBool("die", false);
            animator.SetBool("impact", false);
            animator.SetBool("dash", false);
            animator.SetBool("running", false);
        }
        else
            animator.SetBool("running", false);
    }

    public void setWalkingAnimation(bool active)
    {
        if (active)
        {
            animator.SetBool("finish", false);
            animator.SetBool("running", true);
            animator.SetBool("die", false);
            animator.SetBool("impact", false);
            animator.SetBool("dash", false);
        }
        else
            animator.SetBool("running", false);
    }

    public void SetDashAnimation(bool active)
    {
        if (active)
        {
            animator.SetBool("finish", false);
            animator.SetBool("running", false);
            animator.SetBool("die", false);
            animator.SetBool("impact", false);
            animator.SetBool("dash", true);
        }
        else
            animator.SetBool("dash", false);
    }

    public void SetImpactAnimation(bool active)
    {
        if (active)
        {
            animator.SetBool("finish", true);
            animator.SetBool("running", false);
            animator.SetBool("die", false);
            animator.SetBool("impact", false);
            animator.SetBool("dash", false);
        }
        else
            animator.SetBool("impact", false);
    }

    public void SetDieAnimation(bool active)
    {
        if (active)
        {
            dead = true;
            animator.SetBool("finish", false);
            animator.SetBool("running", false);
            animator.SetBool("die", true);
            animator.SetBool("impact", false);
            animator.SetBool("dash", false);
        }
        else
            animator.SetBool("die", false);
    }

    public void SetFinishAnimation(bool active)
    {
        if (active)
        {
            animator.SetBool("finish", true);
            animator.SetBool("running", false);
            animator.SetBool("die", false);
            animator.SetBool("impact", false);
            animator.SetBool("dash", false);
            animator.SetBool("running", false);
        }
        else
            animator.SetBool("finish", false);
    }

}
