using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : MonoBehaviour
{
    public EntityPlayer Call = null;

    public float velocity = 1.0f;
    public float dash_velocity = 3.0f;
    public float dash_cooldown = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Call = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * (velocity * Time.deltaTime);
        gameObject.transform.Translate(new_position);

    }
}
