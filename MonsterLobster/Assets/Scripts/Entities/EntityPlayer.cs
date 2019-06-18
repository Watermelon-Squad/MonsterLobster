using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : MonoBehaviour
{


    public static EntityPlayer Call = null;

    public float velocity = 1.0f;
    public float dash_velocity = 10.0f;
    public float dash_time = 3.0f;
    public float dash_cooldown = 5.0f;

    private bool dash_finish = false;
    private bool do_dash = false;

    private float actual_time = 0.0f;

    private GameObject collider_attack = null;

    [HideInInspector]
    public float joystic_x = 0.0f;
    [HideInInspector]
    public float joystic_y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Call = this;
        collider_attack = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Yes");
        }

        if (Input.GetKey("joystick button 0") && !dash_finish) // A
        {
            if(!do_dash)
            {
                joystic_x = Input.GetAxis("Horizontal");
                joystic_y = Input.GetAxis("Vertical");
            }

            do_dash = true;

            doAttack(true);
        }
        else
        {
            if(do_dash)
            {
                dash_finish = true;
                actual_time = 0.0f;
                do_dash = false;
                doAttack(false);
            }
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && !do_dash)
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

    private void Movement(float velocity, float x = 0, float y = 0)
    {
        if(x == 0 && y== 0)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

        Vector3 new_position = new Vector3(x, y, 0) * velocity * Time.deltaTime;
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
            doAttack(false);
        }

        Movement(dash_velocity,joystic_x, joystic_y);
    }

    private void doAttack(bool active)
    {
        if (active)
            collider_attack.SetActive(true);
        else
            collider_attack.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Debug.Log("Player hit collision");
        }
    }

}
