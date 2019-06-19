using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AttackPlayer : MonoBehaviour
{
    public GameObject Audio = null;
    bool point = false;
    private Vector3 initial_position = Vector3.zero;
    public Text score;
    int multiplier = 1;
    float timer = 5.0f;

    private void Start()
    {
        initial_position = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = initial_position;
        if (point)
        {
            timer = 5.0f;
            score.text = "x";
            score.text += multiplier.ToString();
            point = false;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0.0f)
        {
            multiplier = 1;
            score.text = "x";
            score.text += multiplier.ToString();
            point = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            multiplier++;
            point = true;
            if(Audio != null)
                Audio.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<DeadEnemy>().death = true;
            transform.parent.GetComponent<fixed_player>().score += collision.gameObject.GetComponent<DeadEnemy>().points;
        }
    }
}
