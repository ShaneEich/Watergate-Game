using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float minimumX = -60f;
    public float maximumX = 60f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public Camera cam;
    private bool locked;

    float rotationX = 0f;
    float rotationY = 0f;

    public GameObject player;
    private Vector3 offset;
    private Vector3 crouchHeight;

    bool crouching = false;
    //public Transform playerPosition;
    //public Transform cameraPosition;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            locked = true;
        }else if (Input.GetMouseButtonDown(1)){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            locked = false;
        }
        if (!locked)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivityY;
            rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

            transform.localEulerAngles = new Vector3(0, rotationY, 0);

            cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
            player.transform.localEulerAngles = new Vector3(0, rotationY, 0);

        }

    }

    private void LateUpdate()
    {
        if (!locked)
        {
            transform.position = player.transform.position + offset;   
        }
    }
}
