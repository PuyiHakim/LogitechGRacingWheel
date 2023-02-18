using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G29Controller : MonoBehaviour
{
    public float gasInput;
    public float brakeInput;
    public float steerInput;

    private void Update()
    {
        gasInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetAxis("Jump");
        steerInput = Input.GetAxis("Horizontal");
    }
}
