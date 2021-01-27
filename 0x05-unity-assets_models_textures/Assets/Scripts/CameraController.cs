using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;

    void Start()
    {
        rotation.y = transform.eulerAngles.y;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();   
    }

    void CameraRotation()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }
}
