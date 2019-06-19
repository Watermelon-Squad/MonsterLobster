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
            if(Audio != null)
                Audio.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<DeadEnemy>().death = true;
            transform.parent.GetComponent<fixed_player>().score += collision.gameObject.GetComponent<DeadEnemy>().points;
        }
    }
}
