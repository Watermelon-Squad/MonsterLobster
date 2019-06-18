using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInteraction : MonoBehaviour
{
    public void onClickPlay()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void onClickQuit()
    {
        Application.Quit();
    }
}
