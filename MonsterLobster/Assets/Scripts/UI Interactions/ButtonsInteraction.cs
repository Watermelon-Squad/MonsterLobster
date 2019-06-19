using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsInteraction : MonoBehaviour
{

	public Image hover;

    public void onClickPlay()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

	public void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
        hover.gameObject.active = true;
	}

    public void OnMouseExit()
    {
        hover.gameObject.active = false;
    }
}
