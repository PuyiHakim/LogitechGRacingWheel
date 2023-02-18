using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearShift : MonoBehaviour
{
    public int currentGear = 1;
    public int maxGears = 6;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5) && currentGear < maxGears)
        {
            currentGear++;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton4) && currentGear > 1)
        {
            currentGear--;
        }
    }
}
