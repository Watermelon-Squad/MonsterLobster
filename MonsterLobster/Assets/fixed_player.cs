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


    private bool dash_inCD = false;
    private float dash_CD_timer = 0.0f;
    private float dash_CD = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (!Player_dash)
        {
            direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            #region movement
            Vector3 new_pos = Vector3.zero;

            #endregion

            #region rotation
            
            float rot = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -rot - 90));
            #endregion
        }

        #region dash

        if (Input.GetMouseButtonDown(0))
        {
            if (!dash_inCD)
            {
                Player_dash = true;
            }
        }

        if (Player_dash)
        {
            gameObject.transform.position -= direction.normalized * dash_speed;
        }

        if (dash_inCD)
        {
            dash_CD_timer += Time.deltaTime;
            if(dash_CD_timer >= dash_CD)
            {
                dash_inCD = false;
            }
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
        dash_inCD = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            life--;

            if (life == 0)
            {
                PlayerAnimations.Call.SetDieAnimation(true);
                PlayerPrefs.SetInt("score", score);
            }


        }
    }
}
