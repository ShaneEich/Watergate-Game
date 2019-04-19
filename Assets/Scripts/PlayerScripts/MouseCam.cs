using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCam : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 0f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Anlges;
    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;

    private float current_Roll_Angle;

    private int last_Look_Frame;
    public PauseMenu pMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //PauseMenu pMenu;
    }

    // Update is called once per frame
    void Update()
    {
        if (pMenu.pauseMenuUI.activeSelf){

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            LockAndUnlockCursor();

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                LookAround();
            }

        }

        
    }

    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    } //Lock Unlock()

    void LookAround()
    {
        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_Anlges.x += current_Mouse_Look.x * sensitivity * (invert ? 1f : -1f);
        look_Anlges.y += current_Mouse_Look.y * sensitivity;

        look_Anlges.x = Mathf.Clamp(look_Anlges.x, default_Look_Limits.x, default_Look_Limits.y);

        //current_Roll_Angle = Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_Angle, Time.deltaTime * roll_Speed);

        lookRoot.localRotation = Quaternion.Euler(look_Anlges.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Anlges.y, 0f);

    }// LookAround()
}
