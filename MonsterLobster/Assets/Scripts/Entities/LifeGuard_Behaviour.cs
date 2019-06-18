using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGuard_Behaviour : MonoBehaviour
{
    public GameObject player;
    private GameObject rubber_float;
    public float fire_cadence = 2.0f;
    private float fire_timer = 0.0f;
    public float float_speed = 2.0f;
    private Vector3 float_dir;
    private bool float_moving = false;
    private bool float_turning = false;
    private float float_range = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        rubber_float = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (!float_moving)
        {

            fire_timer += Time.deltaTime;

            if (fire_timer >= fire_cadence)
            {
                //shoot
                float_dir = player.transform.position;
                float_moving = true;
                fire_timer = 0.0f;
            }
        }

        else
        {
            rubber_float.transform.Translate(new Vector3(float_dir.x, float_dir.y, 0).normalized * float_speed);

            if((rubber_float.transform.position - gameObject.transform.position).magnitude >= float_range)
            {
                float_dir = -float_dir;
                float_turning = true;
            }

            else if ((rubber_float.transform.position - gameObject.transform.position).magnitude <= 0.25f)
            {
                if (float_turning)
                {
                    float_moving = false;
                    float_turning = false;
                }
            }
        }


    }
}
