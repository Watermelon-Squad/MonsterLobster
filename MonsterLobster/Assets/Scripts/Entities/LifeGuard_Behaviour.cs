using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGuard_Behaviour : MonoBehaviour
{
    
    public GameObject player;
    private GameObject rubber_float;
    public float fire_cadence = 2.0f;
    private float fire_timer = 0.0f;
    public float float_speed = 4.0f;
    private Vector3 float_dir;
    private bool float_moving = false;
    private bool float_turning = false;
    private float float_range = 10.0f;

    private Vector3 initial_pos;

    private Vector3 direction = Vector3.zero;
    private Vector3 random_point = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rubber_float = gameObject.transform.GetChild(0).gameObject;
        initial_pos = rubber_float.transform.position;
        rubber_float.SetActive(false);
        ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<DeadEnemy>().death)
        {
            if (!float_moving)
            {

                fire_timer += Time.deltaTime;
                transform.position += direction.normalized * Time.deltaTime;

                if (fire_timer >= fire_cadence)
                {
                    //shoot
                    float_dir = player.transform.position- transform.position;
                    float_moving = true;
                    fire_timer = 0.0f;
                    rubber_float.SetActive(true);
                    ChangeTarget();
                }
            }
            else
            {
                rubber_float.transform.position += new Vector3(float_dir.x, float_dir.y, 0).normalized * float_speed;

                if ((rubber_float.transform.position - gameObject.transform.position).magnitude >= float_range)
                {
                    float_dir = -float_dir;
                    float_turning = true;
                }
                else if (Mathf.Abs((rubber_float.transform.position - gameObject.transform.position).magnitude) <= 1.9f && float_turning)
                {

                    float_moving = false;
                    float_turning = false;
                    rubber_float.transform.position = initial_pos;
                    rubber_float.SetActive(false);

                }
            }
        }
        else
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void ChangeTarget()
    {
        random_point = Random.insideUnitSphere;
        random_point *= 2;
        random_point += transform.position;
        random_point.z = 0;

        direction = random_point - transform.position;
    }
}
