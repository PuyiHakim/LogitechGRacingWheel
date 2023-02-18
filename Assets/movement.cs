using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public LogitechSimple logitech;

    private void Awake()
    {
        logitech = GetComponent<LogitechSimple>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || logitech.xAxes < 0.1f)
        {
            transform.Rotate(0f, logitech.xAxes * 5, 0f);
        }
        else if (Input.GetKey(KeyCode.D) || logitech.xAxes > 0.1f)
        {
            transform.Rotate(0f, logitech.xAxes * 5, 0f);
        }
        else
        {
            transform.Rotate(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S) || logitech.BreakInput > 0)
        {
            transform.Translate(0.0f, 0f, -0.1f);
        }
        if (Input.GetKey(KeyCode.W) || logitech.GasInput > 0)
        {
            transform.Translate(0.0f, 0f, 0.1f);
        }
    }
}
