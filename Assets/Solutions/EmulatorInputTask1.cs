using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorInputTask1 : MonoBehaviour
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
