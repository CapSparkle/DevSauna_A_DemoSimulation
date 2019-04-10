using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAction : MonoBehaviour
{
    AttachPort.OnAttachDelegate Done = DummyMethod();

    Tool requiredActionTool;
    public Tool requiredTool
    {
        get
        {
            return requiredActionTool;
        }
    }

    void DummyMethod()
    {
        pass;
    }

    void Interact(Arm arm)
    {
        Transform armAttachPort = arm.GetChild(0);
        if (armAttachPort.childCount == 1)
        {
            takeable toolInteract = armAttachPort.GetChild(0).GetComponent<takeable>;
            if (requiredActionTool == toolInteract.toolType)
            {
                Done();
            }

        }
    }
}