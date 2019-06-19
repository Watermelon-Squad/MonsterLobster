using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_controller : MonoBehaviour
{
    public GameObject camera;
    public GameObject floor_tiles_parent;
    public GameObject sea_tiles_parent;
    public GameObject player;
    private int tiles_moved = 0;
    private float tiles_width = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        tiles_width = floor_tiles_parent.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sprite.rect.width;
        tiles_width *= floor_tiles_parent.transform.GetChild(0).transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.transform.position.x, -2.8f, -10.0f);
        if(camera.transform.position.x <= (tiles_moved * tiles_width) - tiles_width)
        {
            Debug.Log("Spawn map for left");
            tiles_moved--;
        }

        else if (camera.transform.position.x >= (tiles_moved * tiles_width) + tiles_width)
        {
            Debug.Log("Spawn map for right");
            tiles_moved++;
        }
    }
}
