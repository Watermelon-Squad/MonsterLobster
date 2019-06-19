using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public Image Story_2;
    public Image Story_3;
    public Image Story_4;
    public Image Story_5;

    float timer = 2.0f;
    int actualphoto = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<=0.0f)
        {
            if(actualphoto == 1)
            {
                transform.Translate(new Vector3(1000.0f, 0.0f, 0.0f));
            }
            if (actualphoto == 2)
            {
                Story_2.gameObject.active = false;
            }
            if (actualphoto == 3)
            {
                Story_3.gameObject.active = false;
            }
            if (actualphoto == 4)
            {
                Story_4.gameObject.active = false;     
            }
            if (actualphoto == 5)
            {
                SceneManager.LoadScene("Main Scene");
            }

            timer = 2.0f;
            actualphoto++;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
