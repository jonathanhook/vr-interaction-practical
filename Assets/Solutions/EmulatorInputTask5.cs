using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorInputTask5 : MonoBehaviour
{
    Vector3 last;
    Vector3 delta;

    private bool triggerDown;

    void Start()
    {
        triggerDown = false;

        last = transform.position;
        delta = Vector3.zero;
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
            OnVRControllerTriggerPressed();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnVRControllerTriggerReleased();
        }

        delta = transform.position - last;
        last = transform.position;
    }

    void OnVRControllerTriggerPressed()
    {
        triggerDown = true;
    }

    void OnVRControllerTriggerReleased()
    {
        triggerDown = false;

        SpringJoint spring = GetComponent<SpringJoint>();
        spring.connectedBody = null;
    }

    void OnTriggerStay(Collider c)
    {
        if (triggerDown)
        {
            GameObject target = c.gameObject;
            
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null)
            {
                SpringJoint spring = GetComponent<SpringJoint>();
                spring.connectedBody = rb;
            }
        }
    }
}
