using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTerrain : MonoBehaviour
{

    private bool go_destroy = false;
    private float max_time = 20.0f;
    private float actual_time = 0.0f;

    private void Update()
    {
        if (go_destroy)
        {
            if (actual_time < max_time)
                actual_time += Time.deltaTime;
            else
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        go_destroy = false;
        actual_time = 0.0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            go_destroy = true;
    }
}
