using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGuard_Behaviour : MonoBehaviour
{

    public GameObject rubber_float;
    public float fire_cadence = 2.0f;
    private float fire_timer = 0.0f;
    public float float_speed = 2.0f;
    private Vector3 float_dir;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire_timer += Time.deltaTime;

        if (fire_timer >= fire_cadence)
        {
            //shoot
            fire_timer = 0.0f;
        }


    }
}
