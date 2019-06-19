using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    public int points = 30;
    private Animator animator = null;
    public bool death = false;
    int once = 0;
    public GameObject[] blood;
    public AudioClip[] audios_enemy;

    // Update is called once per frame

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(death)
        {
           
            animator.SetBool("attack", false);
            animator.SetBool("death", true);
            BloodStain();
        }
    }

    void BloodStain()
    {
        if (once == 0)
        {
            AudioSource audiosource = gameObject.GetComponent<AudioSource>();
            audiosource.PlayOneShot(audios_enemy[0]);
            audiosource.PlayOneShot(audios_enemy[1]);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Instantiate(blood[Random.RandomRange(0, 2)], transform.position, transform.rotation);
            once++;
        }
    }


}
