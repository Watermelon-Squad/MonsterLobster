using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] go;

    private void Start()
    {
        if (go.Length - 1 > 0)
        {
            int r = Random.Range(0, go.Length - 1);

            GameObject.Instantiate(go[r],transform);
        }
    }
    
}
