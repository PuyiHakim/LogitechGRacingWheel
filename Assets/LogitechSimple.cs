using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogitechSimple : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    public float xAxes, GasInput, BreakInput, ClutchInput;

    public bool HShift = true;
    bool isInGear;
    public int CurrentGear;

    private void Start()
    {
        print(LogitechGSDK.LogiSteeringInitialize(false));
    }

    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);
            HShifter(rec);
            xAxes = rec.lX / 32768f;

            if (rec.lY > 0)
            {
                GasInput = 0;
            }
            else if (rec.lY < 0)
            {
                GasInput = rec.lY / -32768f;
            }

            if (rec.lRz > 0)
            {
                BreakInput = 0;
            }
            else if (rec.lRz < 0)
            {
                BreakInput = rec.lRz / -32768f;
            }

            if (rec.rglSlider[0] > 0)
            {
                ClutchInput = 0;
            }
            else if (rec.rglSlider[0] < 0)
            {
                ClutchInput = rec.rglSlider[0] / -32768f;
            }
        }
        else
        {
            print("No Steering Wheel Connected!");
        }
    }

    void HShifter(LogitechGSDK.DIJOYSTATE2ENGINES shifter)
    {
        for (int i = 0; i < 128; i++)
        {
            if (shifter.rgbButtons[i] == 128)
            {
                if (ClutchInput > 0.5f)
                {
                    if (i == 12)
                    {
                        CurrentGear = 1;
                        isInGear = true;
                    }
                    else if (i == 13)
                    {
                        CurrentGear = 2;
                        isInGear = true;
                    }
                    else if (i == 14)
                    {
                        CurrentGear = 3;
                        isInGear = true;
                    }
                    else if (i == 15)
                    {
                        CurrentGear = 4;
                        isInGear = true;
                    }
                    else if (i == 16)
                    {
                        CurrentGear = 5;
                        isInGear = true;
                    }
                    else if (i == 17)
                    {
                        CurrentGear = 6;
                        isInGear = true;
                    }
                    else if (i == 18)
                    {
                        CurrentGear = -1;
                        isInGear = true;
                    }
                    else
                    {
                        CurrentGear = 0;
                        isInGear = false;
                    }
                }
            }
        }
    }
}