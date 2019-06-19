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
    [HideInInspector]
    public bool do_dash = false;

    private float actual_time = 0.0f;

    private GameObject collider_attack = null;

    [HideInInspector]
    public float joystic_x = 0.0f;
    [HideInInspector]
    public float joystic_y = 0.0f;

    public Vector3 direction = -Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        Call = this;
        collider_attack = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") >= 0.2 && !dash_finish) // A
        {
            
            if(!do_dash)
            {
                joystic_x = Input.GetAxis("Horizontal")* Input.GetAxisRaw("Fire1");
                joystic_y = Input.GetAxis("Vertical")* Input.GetAxisRaw("Fire1");
               
            }

            do_dash = true;

            doAttack(true);
        }
       

        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.2 || Mathf.Abs(Input.GetAxis("Vertical")) >= 0.2 && !do_dash)
        {
            PlayerAnimations.Call.setWalkingAnimation(true);
            Movement(velocity, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
            PlayerAnimations.Call.setWalkingAnimation(false);

        if (do_dash)
        {
            PlayerAnimations.Call.SetDashAnimation(true);
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
                PlayerAnimations.Call.SetFinishAnimation(false);
            }
        }

    }

    private void Movement(float velocity, float x = 0, float y = 0)
    {
 
        float horizontal = x * velocity * Time.deltaTime;
        float vertical = y * velocity * Time.deltaTime;
        float rotZ = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;

        Vector3 new_position = new Vector3( horizontal,  vertical, 0);
        direction =  new_position;
        gameObject.transform.position += new_position;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rotZ + 90));

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
            PlayerAnimations.Call.SetImpactAnimation(false);
            PlayerAnimations.Call.SetFinishAnimation(true);
        }

        gameObject.transform.position += direction * dash_velocity;
    }

    private void doAttack(bool active)
    {
        if (active)
            collider_attack.SetActive(true);
        else
        {
            collider_attack.SetActive(false);
            PlayerAnimations.Call.SetDashAnimation(false);
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
