using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixed_player : MonoBehaviour
{

    [HideInInspector]
    public int score = 0;

    public int life = 3;
    public static fixed_player Call = null;
    //Animations
    public Animator player_animator;
    private bool Player_dead = false;
    public bool Player_dash = false;
    private bool Player_walk = false;

    public float speed = 50.0f;

    public float dash_speed = 15.0f;

    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        Call = this;   
    }

    // Update is called once per frame
    void Update()
    {

       

        if (!Player_dash)
        {
            direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            #region movement
            Vector3 new_pos = Vector3.zero;

            Player_walk = false;

            if (Input.GetKey(KeyCode.W))
            {
                new_pos.y += speed;
                Player_walk = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                new_pos.y -= speed;
                Player_walk = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                new_pos.x -= speed;
                Player_walk = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                new_pos.x += speed;
                Player_walk = true;
            }

            gameObject.transform.position += new_pos * Time.deltaTime;

            #endregion

            #region rotation
            
            float rot = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rot - 90));
            #endregion
        }

        #region dash

        if (Input.GetMouseButtonDown(0))
        {
            Player_dash = true;
        }

        if (Player_dash)
        {
            gameObject.transform.position -= direction.normalized * dash_speed;
        }

        #endregion

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f);

        player_animator.SetBool("Player_dead", Player_dead);
        player_animator.SetBool("Player_dashing", Player_dash);
        player_animator.SetBool("Player_walking", Player_walk);
    }

    private void DashEnded()
    {
        Player_dash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            life--;

            if (life == 0)
            {
                player_animator.SetBool("Player_dead", true);
                PlayerPrefs.SetInt("score", score);
            }


        }
    }
}
