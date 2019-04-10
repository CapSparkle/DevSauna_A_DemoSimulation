using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPort : MonoBehaviour
{
    public delegate void OnAttachDelegate();

    OnAttachDelegate Done = DummyMethod();

    Tool attachRequiredTool;
    public Tool requiredTool
    {
        get
        {
            return attachRequiredTool;
        }
    }

    void DummyMethod()
    {
        pass;
    }

    public void AttachTool(ref Arm arm)
    {

        Transform armAttachPort = arm.GetChild(0);
        if (armAttachPort.childCount == 1)
        {
            takeable toolToAttach = armAttachPort.GetChild(0).GetComponent<takeable>;
            if (attachRequiredTool == toolToAttach.toolType)
            {
                arm.GetChild(0).SetParent(gameObject);
                Done();
                
                // временная переменная. Скоро ее удалим.  
                arm.currentEquipedTool = null;
            }
        }
        else
        {
            return;
        }
        
        // вызывается событие OnAttach
        // оповещаются все кто интересуется
    }
}
