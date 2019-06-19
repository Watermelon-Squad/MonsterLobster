using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDissapear : MonoBehaviour
{
    float timer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0.0f)
        {
            Object.Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }
}
