using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {

    [SerializeField] private string mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float yAxisClamp;

    private void Awake()
    {
        LockCursor();
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
        yAxisClamp += mouseY;
        if (yAxisClamp > 90.0f)
        {
            yAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampYAxisRotationToValue(270.0f);
        }
        else if (yAxisClamp < -90.0f)
        {
            yAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampYAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
    }

    private void ClampYAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        transform.eulerAngles = eulerRotation;
    }
}
