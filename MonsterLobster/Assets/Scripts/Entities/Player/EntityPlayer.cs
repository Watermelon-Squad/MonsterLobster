using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityPlayer : MonoBehaviour
{
    public int life = 3;
    public static EntityPlayer Call = null;

    public float velocity = 1.0f;

    public float dash_velocity = 8.0f;

    private bool charging_dash = false;
    private float charging_timer = 0.0f;
    public float charging_max_time = 3.0f;
    private Vector3 dash_dir;

    [HideInInspector]
    public bool dashing = false;

    private float dashing_timer = 0.0f;

    private GameObject collider_attack = null;

    private float revive_timer = 0.0f;
    private float revive_maxTime = 2.0f;
    private bool reviving = false;


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

        if (Input.GetKey(KeyCode.D))
            reviving = true;

        if (reviving)
        {

            if (gameObject.transform.GetComponent<SpriteRenderer>().enabled)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
            }

            else
            {
                gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;
            }


            revive_timer += Time.deltaTime;
            if(revive_timer >= revive_maxTime)
            {
                reviving = false;
                revive_timer = 0.0f;
                gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        //Movement
        Vector3 new_position = Vector3.zero;
        if (!dashing)
        {
            if (Input.GetKey(KeyCode.W))
                new_position.y += velocity;
            if (Input.GetKey(KeyCode.S))
                new_position.y -= velocity;
            if (Input.GetKey(KeyCode.A))
                new_position.x -= velocity;
            if (Input.GetKey(KeyCode.D))
                new_position.x += velocity;
        }
        if (new_position != Vector3.zero)
            PlayerAnimations.Call.setWalkingAnimation(true);


        gameObject.transform.position += new_position * Time.deltaTime;

        //Rotation

        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (!dashing)
        {
            direction = transform.position - mouse_position;
            float rot = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rot - 90));
        }

        //

        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimations.Call.SetDashAnimation(true);
            charging_dash = true;
            dash_dir = direction;
        }

        if (Input.GetMouseButtonUp(0) || charging_timer >= charging_max_time)
        {
            PlayerAnimations.Call.SetImpactAnimation(true);
            dashing = true;
            charging_dash = false;
        }

        if (charging_dash)
        {
            charging_timer += Time.deltaTime;
        }

        else if (dashing)
        {
            collider_attack.SetActive(true);
            gameObject.transform.position -= direction.normalized * dash_velocity * Time.deltaTime; 
            dashing_timer += Time.deltaTime;

            if(dashing_timer > charging_timer)
            {
                collider_attack.SetActive(false);
                dashing = false;
                dashing_timer = 0.0f;
                charging_timer = 0.0f;
                PlayerAnimations.Call.setIdleAnimation(true);
            }
        }

        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0.0f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            life--;

            if (life == 0)
                SceneManager.LoadScene("Scoreboard Scene");

        }
    }

}
