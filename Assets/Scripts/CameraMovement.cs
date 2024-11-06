using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensitivity;

    private float xRotation = 0f;
    private float yRotation = 0f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = gameManager.sensitivity * 10f;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = (Input.GetAxis("Mouse X") * 0.1f * Time.deltaTime) * mouseSensitivity;
        float mouseY = (Input.GetAxis("Mouse Y") * 0.1f * Time.deltaTime) * mouseSensitivity;

        xRotation -= mouseY;
        yRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);


        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

    }
}
