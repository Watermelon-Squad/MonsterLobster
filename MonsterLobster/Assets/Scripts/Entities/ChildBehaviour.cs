using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBehaviour : MonoBehaviour
{

    public float speed = 1.0f;
    private Vector2 direction = Vector2.zero;
    private Vector3 random_point = Vector3.zero;
    private bool arrived = true;

    public float radius = 1.0f;

    private float actual_time = 0.0f;
    public float max_update = 6.0f;

    public float offset_distance = 0.4f;

    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<DeadEnemy>().death)
        {
            if (!arrived)
            {
                gameObject.transform.Translate(direction * speed * Time.deltaTime);


                if (actual_time >= max_update)
                {
                    arrived = true;
                    actual_time = 0.0f;
                }
                else
                    actual_time += Time.deltaTime;

            }
            else
            {
                ChangeTarget();
                arrived = false;
            }
        }
    }

    void ChangeTarget()
    {
        random_point = Random.insideUnitSphere;
        random_point *= radius;
        random_point += transform.position;
        random_point.z = 0;

        direction = random_point - transform.position ;
    }


}
