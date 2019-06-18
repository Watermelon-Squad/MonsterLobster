﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : MonoBehaviour
{
    [HideInInspector]
    public static EntityPlayer Call = null;

    public float velocity = 1.0f;
    public float dash_velocity = 10.0f;
    public float dash_time = 3.0f;
    public float dash_cooldown = 5.0f;

    private bool dash_finish = false;
    private bool do_dash = false;

    private float actual_time = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Call = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("joystick button 0") && !dash_finish) // A
        {
            do_dash = true;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Movement(velocity);
        }

        if(do_dash)
        {
            Dash();
        }

        if(dash_finish)
        {
            if (actual_time <= dash_cooldown)
                actual_time += Time.deltaTime;
            else
            {
                actual_time = 0;
                dash_finish = false;
            }
        }
        
    }

    private void Movement(float velocity)
    {
        Vector3 new_position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * velocity * Time.deltaTime;
        gameObject.transform.Translate(new_position);
    }

    private void Dash()
    {
        if (actual_time <= dash_time)
            actual_time += Time.deltaTime;
        else
        {
            dash_finish = true;
            actual_time = 0.0f;
            do_dash = false;
        }

        Movement(dash_velocity);
    }
}