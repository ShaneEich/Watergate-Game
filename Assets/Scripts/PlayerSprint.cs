using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    float stamina = 2, maxStamina = 2;
    float walkSpeed, runSpeed;
    PlayerController pc;
    bool isRunning;

    Rect staminaRect;
    Texture2D staminaTexture;
    Color newColor = new Color(255/255f, 100/255f, 30/255f, .4f);
    
    void Start()
    {
        pc = gameObject.GetComponent<PlayerController>();
        walkSpeed = pc.walkSpeed;
        runSpeed = walkSpeed * 2.5f;

        staminaRect = new Rect(Screen.width / 85, Screen.height * .95f, Screen.width / 85, -Screen.height / 4);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, newColor);
        staminaTexture.Apply();

    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        pc.walkSpeed = isRunning ? runSpeed : walkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetRunning(true);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if(isRunning)
        {
            stamina -= Time.deltaTime;
            if(stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }else if(stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        //float rectWidth = ratio * Screen.width / 85;
        float rectHeight = ratio * -Screen.height / 4;
        staminaRect.height = rectHeight;
        GUI.DrawTexture(staminaRect, staminaTexture);

    }
}
