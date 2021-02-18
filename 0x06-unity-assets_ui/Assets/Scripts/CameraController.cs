using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;
    public bool isInverted;

    void Start()
    {
        rotation.y = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();   
    }

    void CameraRotation()
    {
        float horizontalRotationPlayer = Input.GetAxis("Mouse X") * lookSpeed;
        rotation.y = Input.GetAxis("Mouse X") * lookSpeed;
        if (!isInverted)
        {
            rotation.x -= -Input.GetAxis("Mouse Y") * lookSpeed;
        }
        else
        {
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        }
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);

        float y = Mathf.Round(transform.eulerAngles.y * lookSpeed);
        Vector3 cameraEulerAngles = new Vector3(0, y, 0);

        playerCameraParent.parent.eulerAngles = cameraEulerAngles;
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        
        transform.eulerAngles = new Vector2(0, rotation.y);
        transform.LookAt(playerCameraParent.parent.transform);
    }
}
