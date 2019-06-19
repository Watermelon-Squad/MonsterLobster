using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TerrainGenerator : MonoBehaviour
{
    [HideInInspector]
    public GameObject go = null;

    public bool is_left = true;
    public GameObject[] gameObjects;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (go == null)
            {
                int r = Random.Range(0, gameObjects.Length - 1);
                Vector3 new_position = Vector3.zero;

                if (is_left)
                {
                    new_position = new Vector3(transform.parent.parent.position.x - 28.7f, transform.parent.parent.position.y, transform.parent.parent.position.z);
                }
                else
                {
                    new_position = new Vector3(transform.parent.parent.position.x + 28.7f, transform.parent.parent.position.y, transform.parent.parent.position.z);
                }

                go = GameObject.Instantiate(gameObjects[r], new_position, transform.parent.parent.rotation);
                go.transform.GetChild(2).GetChild(0);

                if (is_left)
                    if(go.transform.GetChild(2).GetChild(0).childCount > 0)
                    go.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TerrainGenerator>().go = transform.parent.parent.gameObject;
                else
                    {
                        if (go.transform.GetChild(2).GetChild(0).childCount > 0)
                            go.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TerrainGenerator>().go = transform.parent.parent.gameObject;
                    }
                       

            }
            
        }
    }

}
