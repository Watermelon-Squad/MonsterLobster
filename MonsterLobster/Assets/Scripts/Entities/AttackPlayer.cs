using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float offset_x = 1.0f;
    public float offset_y = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position = new Vector3(Input.GetAxis("Horizontal") * offset_x, Input.GetAxis("Vertical")* offset_y, 0);

        transform.position = gameObject.transform.parent.position + new_position;
    }
}
