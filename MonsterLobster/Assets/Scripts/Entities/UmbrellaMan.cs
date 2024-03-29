﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaMan : MonoBehaviour
{
    
    public float speed = 1.0f;
    public float max_time_running = 4.0f;
    public float max_time_defending = 3.0f;
    public float max_magnitude = 3.0f;
    public float min_distance_to_defense = 1.0f;
    private Vector3 direction = Vector3.zero;
    private float actual_time = 0.0f;

    bool attack_mode = true;


    // Start is called before the first frame update
    void Start()
    {
        actual_time = max_time_running;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<DeadEnemy>().death)
        {
            if (attack_mode)
            {
                if (actual_time <= max_time_running)
                {
                    actual_time += Time.deltaTime;

                    transform.position += direction * speed * Time.deltaTime;

                    if ((fixed_player.Call.gameObject.transform.position - transform.position).magnitude < min_distance_to_defense && (fixed_player.Call.Player_dash1 || fixed_player.Call.Player_dash2))
                    {
                        attack_mode = false;
                        actual_time = 0.0f;
                    }
                }
                else
                {
                    RecalculateDirection();
                    actual_time = 0.0f;
                }
            }
            else
            {
                if (actual_time < max_time_defending)
                    actual_time += Time.deltaTime;
                else
                {
                    actual_time = max_time_running;
                    attack_mode = true;
                }
            }

            float rot = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rot - 90));
        }
    }


    private void RecalculateDirection()
    {
        direction = fixed_player.Call.gameObject.transform.position - transform.position;
        
        if (direction.magnitude > max_magnitude)
            direction = direction.normalized * max_magnitude;


    }

}
