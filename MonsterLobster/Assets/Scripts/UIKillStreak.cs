using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKillStreak : MonoBehaviour
{
    private Scrollbar scrollbar = null;
    private Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        scrollbar = transform.GetChild(1).GetComponent<Scrollbar>();
        text = transform.GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
