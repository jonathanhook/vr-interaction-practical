using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorController : MonoBehaviour
{
    public float mouseSensitivity = 5.0f;

    private CharacterController controller;
    private Camera headCamera;

    private float walkingSpeed = 2.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        headCamera = GetComponentInChildren<Camera>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0.0f, mx, 0.0f);

        float my = Input.GetAxis("Mouse Y") * mouseSensitivity;
        headCamera.transform.Rotate(-my, 0.0f, 0.0f);

        float vMov = Input.GetAxis("Vertical");
        controller.Move(vMov * transform.forward * Time.deltaTime * walkingSpeed);
    }
}