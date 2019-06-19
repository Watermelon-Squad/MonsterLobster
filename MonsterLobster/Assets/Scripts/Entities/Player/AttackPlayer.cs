using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public GameObject Audio = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            PlayerAnimations.Call.SetImpactAnimation(true);
            Audio.GetComponent<AudioSource>().Play();
        }
    }
}
