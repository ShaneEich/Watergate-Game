using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    public string currentPassword;
    public string input;
    public bool onTrigger;
    public bool doorOpened;
    public bool keypadScreen;
    public Transform hinge;
    private int fails = 0;

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    private void Start()
    {
        Clue[] scripts = FindObjectsOfType<Clue>();
        int num1, num2, num3, num4;
        num1 = Random.Range(0, 10);
        num2 = Random.Range(0, 10);
        num3 = Random.Range(0, 10);
        num4 = Random.Range(0, 10);
        currentPassword = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
        for (int i = 0; i < scripts.Length; i++)
        {
            if(i == 0)
            {
                scripts[i].clueText = num1.ToString() + " _ _ _";
            }
            else if (i == 1)
            {
                scripts[i].clueText = "_ " + num2.ToString() + " _ _";
            }
            else if (i == 2)
            {
                scripts[i].clueText = "_ _ " + num3.ToString() + " _";
            }
            else if (i == 3)
            {
                scripts[i].clueText = "_ _ _ " + num4.ToString();
            }
        }
    }

    private void Update()
    {
        if(input.Length == 4 && input != currentPassword)
        {
            fails += 1;
            input = "";
        }
        if(fails >= 3)
        {
            Scene s = SceneManager.GetActiveScene();
            SceneManager.LoadScene(s.name);
        }
        if(input == currentPassword)
        {
            doorOpened = true;
        }

        if (doorOpened)
        {
            var newRot = Quaternion.RotateTowards(hinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            hinge.rotation = newRot;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            input = input + "0";
        }else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            input = input + "1";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            input = input + "2";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            input = input + "3";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            input = input + "4";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            input = input + "5";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            input = input + "6";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            input = input + "7";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            input = input + "8";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            input = input + "9";
        }
    }

    private void OnGUI()
    {
        if (!doorOpened)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open Keypad");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }
            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);

                //make the GUI buttons and get inputs for the keypad
                if (GUI.Button(new Rect(5, 350, 100, 100), "Clear") || Input.GetKeyDown(KeyCode.Backspace))
                {
                    input = "";
                }

                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }

                if (GUI.Button(new Rect(5, 245, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(110, 245, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(215, 245, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(5, 35, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(110, 35, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(215, 35, 100, 100), "9"))
                {
                    input = input + "9";
                }
            }
        }
    }

}
