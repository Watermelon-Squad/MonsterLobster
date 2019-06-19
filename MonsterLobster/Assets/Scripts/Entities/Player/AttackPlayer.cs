using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float offset_x = 0.2f;
    public float offset_y = 0.2f;

    // Update is called once per frame
    void Update()
    {
      //  Vector3 new_position = new Vector3(EntityPlayer.Call.joystic_x * offset_x, EntityPlayer.Call.joystic_y * offset_y, 0);

       // transform.position = gameObject.transform.parent.position + new_position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
            Destroy(collision.gameObject);
    }
}
