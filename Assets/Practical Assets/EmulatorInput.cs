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
        /* When completing the optional HTC Vive practical exercises in your 
         * indivdiual access slot, you should be able to adapt your code to work 
         * based on the buttons on the Vive controller by replacing the calls
         * to Input.GetMouse... with calls to the SteamVR API. For example, you
         * would use code allow the following lines to get check if the trigger
         * under the left controller is pressed / released:
         * 
         * SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand)
         * SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand)
         */
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