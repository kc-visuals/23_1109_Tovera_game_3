using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    Vector2 mouseSensitivity;

    float rotationV;

    [SerializeField]
    float minV;

    [SerializeField]
    float maxV;

    public bool lookEnabled;

    Vector2 mouseMovementValue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        lookEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookEnabled)
        {
            mouseMovementValue = Mouse.current.delta.ReadValue();
            transform.Rotate(0, mouseMovementValue.x * mouseSensitivity.x, 0);

            rotationV -= mouseMovementValue.y * mouseSensitivity.y;

            rotationV = Mathf.Clamp(rotationV, minV, maxV);
            playerCamera.localEulerAngles = new Vector3(rotationV, 0, 0);
        }
        
    }
}
