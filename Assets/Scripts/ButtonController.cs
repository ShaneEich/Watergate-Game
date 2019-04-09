using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum FUNC {START, HOWTO, QUIT}
public class ButtonController : MonoBehaviour
{
    public FUNC state;
    public void OnClick()
    {
        if (state == FUNC.START)
        {
            SceneManager.LoadScene("Lobby");
        }
        else if (state == FUNC.HOWTO)
        {
            SceneManager.LoadScene("HowToPlay");
        }
        else if (state == FUNC.QUIT)
        {
            Application.Quit();
        }
    }
}
