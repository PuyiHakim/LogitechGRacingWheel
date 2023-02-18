using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputCondition
{
    KeyBoard = 0, Mobile = 1, Driving = 2
};


public class InputManager : MonoBehaviour
{
    [HideInInspector] public float gasInput;
    [HideInInspector] public float clutchInput;
    [HideInInspector] public float brakeInput;
    [HideInInspector] public float steerInput;
    [HideInInspector] public int gearInput;
    [HideInInspector] public bool XInput;
    [HideInInspector] public bool OInput;
    [HideInInspector] public bool SInput;
    [HideInInspector] public bool TInput;
    public InputCondition inputCondition;

    // Start is called before the first frame update

    void Start()
    {
        print("LogiSteeringInitialize: " + LogitechGSDK.LogiSteeringInitialize(false));    
    }

    // Update is called once per frame

    void Update()
    {
        switch (inputCondition)
        {
            case InputCondition.KeyBoard:
                print("KEYBOARD");
                break;
            case InputCondition.Mobile:
                print("MOBILE");
                break;
            case InputCondition.Driving:
                print("DRIVING WHEEL");
                if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected((int)LogitechKeyCode.FirstIndex))
                {
                    #region
                    //Getting Logitech Pedal and Steering axis Input Values in float datatype
                    steerInput = LogitechInput.GetAxis("Steering Horizontal");
                    gasInput = LogitechInput.GetAxis("Gas Vertical");
                    brakeInput = LogitechInput.GetAxis("Brake Vertical");
                    clutchInput = LogitechInput.GetAxis("CLutch Vertical");
                    #endregion

                    #region
                    //Getting Logitech SHifter INputs in integer Datatype
                    for (int i = 12; i < 19; i++)
                    {
                        if(LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, (LogitechKeyCode)i))
                        {
                            // for 1-7 Gears of Logitech Shiter (WITH REVERSE IF REQUEST)
                            gearInput = i;
                            print(gearInput);
                        }
                        if (LogitechInput.GetKeyReleased(LogitechKeyCode.FirstIndex, (LogitechKeyCode)i))
                        {
                            // for Manual GEAR
                            gearInput = 0;
                            print(gearInput);
                        }
                    }
                    #endregion

                    #region
                    // Steering Button Inputs
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Cross))
                        XInput = !XInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Circle))
                        OInput = !OInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Square))
                        SInput = !SInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Triangle))
                        TInput = !TInput;
                    // Rest of the BUtton L2 && R2, L3 & R3, left and right bumper share options and ps

                    //Direction button inputs
                    switch (LogitechInput.GetKeyDirectional())
                    {
                        case (0):                                       print("POV : UP");  break;
                        case ((uint)LogitechKeyCode.UP_RIGHTButton):    print("POV : UP-RIGHT\n");    break;
                        case ((uint)LogitechKeyCode.RIGHTButton):       print("POV : RIGHT\n");   break;
                        case ((uint)LogitechKeyCode.DOWN_RIGHTButton):  print("POV : DOWN-RIGHT\n");    break;
                        case ((uint)LogitechKeyCode.DOWNButton):        print("POV : DOWN\n "); break;
                        case ((uint)LogitechKeyCode.DOWN_LEFTButton):   print("POV: DOWN-LEFT\n");  break;
                        case ((uint)LogitechKeyCode.LEFTButton):        print("POV : LEFT\n");  break;
                        case ((uint)LogitechKeyCode.UP_LEFTButton):     print("POV : UP-LEFT\n");   break;
                        default:                                        print("CENTER\n");  break;
                    }
                    #endregion
                }
                else if (!LogitechGSDK.LogiIsConnected(0))
                {
                    print("PLEASE CONNECT THE LOGITECH DRIVING FORCE WHEEL");
                }
                break;
        }
    }
}