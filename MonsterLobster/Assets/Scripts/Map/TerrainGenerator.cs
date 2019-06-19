using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TerrainGenerator : MonoBehaviour
{
    private GameObject go = null;

    public bool is_left = true;
    public GameObject[] gameObjects;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if(go == null)
            {
                int r = Random.Range(0, gameObjects.Length - 1);
                Vector3 new_position = Vector3.zero;

                if(is_left)
                {
                    new_position = new Vector3(transform.parent.parent.position.x - 28.7f, transform.parent.parent.position.y, transform.parent.parent.position.z);
                }
                else
                {
                    new_position = new Vector3(transform.parent.parent.position.x + 28.7f, transform.parent.parent.position.y, transform.parent.parent.position.z);
                }

                go = GameObject.Instantiate(gameObjects[r],new_position, transform.parent.parent.rotation);
            }
        }
    }

}
