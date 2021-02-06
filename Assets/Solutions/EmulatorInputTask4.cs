using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorInputTask4 : MonoBehaviour
{
    Vector3 last;
    Vector3 delta;

    private bool triggerDown;
    private GameObject target;

    void Start()
    {
        triggerDown = false;
        target = null;

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

        if(target != null)
        {
            target.transform.parent = null;
            target.GetComponent<Rigidbody>().isKinematic = false;
            target.GetComponent<Rigidbody>().AddForce(delta * 250.0f);
            target = null;
        }
    }

    void OnTriggerStay(Collider c)
    {
        if(triggerDown && target == null)
        {
            target = c.gameObject;
            target.transform.parent = transform;
            target.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
