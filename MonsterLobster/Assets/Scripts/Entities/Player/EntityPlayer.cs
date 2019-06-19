using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : MonoBehaviour
{
    public static EntityPlayer Call = null;

    public float velocity = 1.0f;

    public float dash_velocity = 8.0f;
    public float dash_time = 3.0f;
    public float dash_time_charge = 3.0f;
    public float dash_cooldown = 5.0f;

    private bool dash_finish = false;
    [HideInInspector]
    public bool do_dash = false;

    private float actual_time = 0.0f;
    private float actual_dash_time = 0.0f;

    private GameObject collider_attack = null;


    private Vector3 direction = -Vector3.left;
    private Vector3 direction_dash = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Call = this;
        collider_attack = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector3 new_position = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
            new_position.y += velocity;
        if (Input.GetKey(KeyCode.S))
            new_position.y -= velocity;
        if (Input.GetKey(KeyCode.A))
            new_position.x -= velocity;
        if (Input.GetKey(KeyCode.D))
            new_position.x += velocity;

        if (new_position != Vector3.zero)
            PlayerAnimations.Call.setWalkingAnimation(true);
        else
            PlayerAnimations.Call.setWalkingAnimation(false);

        gameObject.transform.position += new_position * Time.deltaTime;

        //Rotation

        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mouse_position;
        
        if (!do_dash)
        {
            float rot = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rot - 90));
            PlayerAnimations.Call.SetFinishAnimation(false);
        }

        //Dash
        if (!dash_finish)
        {
            if (Input.GetMouseButton(0))
            {
                if (actual_time <= dash_time_charge)
                    actual_time += Time.deltaTime;
            }
            else if (actual_time > 0 && !do_dash)
            {
                do_dash = true;
                direction_dash = mouse_position - transform.position;
                direction_dash.z = 0;
                doAttack(true);
            }
        }

        if(do_dash)
        {
            dash_time = actual_time;
            if (actual_dash_time <= dash_time)
            {
                actual_dash_time += Time.deltaTime;

                gameObject.transform.position += direction_dash.normalized * dash_velocity * Time.deltaTime;
            }
            else
            {
                actual_dash_time = 0.0f;
                actual_time = 0.0f;
                do_dash = false;
                dash_finish = true;
                doAttack(false);
            }  
        }

        //Cooldown
        if(dash_finish)
        {
            if (actual_time <= dash_cooldown)
                actual_time += Time.deltaTime;
            else
            {
                actual_time = 0.0f;
                dash_finish = false;
            }
        }

    }


    private void doAttack(bool active)
    {
        if (active)
        {
            collider_attack.SetActive(true);
            PlayerAnimations.Call.SetDashAnimation(true);
        }
        else
        {
            collider_attack.SetActive(false);
            PlayerAnimations.Call.SetDashAnimation(false);
            PlayerAnimations.Call.SetImpactAnimation(false);
            PlayerAnimations.Call.SetFinishAnimation(true);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Debug.Log("Player hit collision");
        }
    }

}
