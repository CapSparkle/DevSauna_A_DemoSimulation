using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    // временная переменная. Скоро ее удалим. 
    public takeable currentEquipedTool;
    public takeable equipedTool
    {
        get
        {
            return currentEquipedTool;
        }
    }

    void GetTool(ref takeable toolToTake)
    {
        Transform armAttachPort = gameObject.GetChild(0);
        if (armAttachPort.childCount == 0)
        {
            toolToTake.SetParent(armAttachPort);
            toolToTake.position = Vector3(0.0f, 0.0f, 0.0f);
        }
        else
        {
            return;
        }

        currentEquipedTool = toolToTake;
    }

    void DropTool()
    {
        Transform armAttachPort = gameObject.GetChild(0);
        if (armAttachPort.childCount == 1)
        {
            armAttachPort.GetChild(0).parent = null;
        }
        else
        {
            return;
        }

        currentEquipedTool = null;
    }
}
