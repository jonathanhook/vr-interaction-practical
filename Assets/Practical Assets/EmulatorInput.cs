using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            OnVRControllerButtonPressed();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnVRControllerButtonReleased();
        }
    }

    void OnVRControllerButtonPressed()
    {
        // put the code you want to happen when the trigger is pressed here
        Debug.Log("Trigger pressed");
    }

    void OnVRControllerButtonReleased()
    {
        // put the code you want to happen when the trigger is pressed here
        Debug.Log("Trigger released");
    }

}
