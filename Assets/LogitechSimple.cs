using UnityEngine;

public class LogitechSimple : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    public float xAxes, GasInput, BreakInput, ClutchInput;

    public bool HShift = true;
    private bool _isInGear;
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
                        _isInGear = true;
                    }
                    else if (i == 13)
                    {
                        CurrentGear = 2;
                        _isInGear = true;
                    }
                    else if (i == 14)
                    {
                        CurrentGear = 3;
                        _isInGear = true;
                    }
                    else if (i == 15)
                    {
                        CurrentGear = 4;
                        _isInGear = true;
                    }
                    else if (i == 16)
                    {
                        CurrentGear = 5;
                        _isInGear = true;
                    }
                    else if (i == 17)
                    {
                        CurrentGear = 6;
                        _isInGear = true;
                    }
                    else if (i == 18)
                    {
                        CurrentGear = -1;
                        _isInGear = true;
                    }
                    else
                    {
                        CurrentGear = 0;
                        _isInGear = false;
                    }
                }
            }
        }
    }
}