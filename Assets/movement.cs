using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LogitechSimple _logitechSimple;
    
    [SerializeField] private int _currentGear = 1;
    [SerializeField] private int _maxGears = 6;
    
    [SerializeField] private Vector3 normalLookPosition;
    [SerializeField] private Vector3 normalLookRotation;
    [SerializeField] private Vector3 leftLookPosition;
    [SerializeField] private Vector3 leftLookRotation;
    [SerializeField] private Vector3 rightLookPosition;
    [SerializeField] private Vector3 rightLookRotation;
    [SerializeField] private Vector3 backLookPosition;
    [SerializeField] private Vector3 backLookRotation;
    
    [SerializeField] private Transform _cameraTransform;
    
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }
    
    private void Update()
    {
        if (_logitechSimple == null) return;

        LogitechGSDK.DIJOYSTATE2ENGINES rec;
        rec = LogitechGSDK.LogiGetStateUnity(0);

        for (int i = 0; i < 128; i++)
        {
            if (rec.rgbButtons[i] == 128)
            {
                if (i == 0)
                {
                    _cameraTransform.localPosition = normalLookPosition;
                    _cameraTransform.localEulerAngles = normalLookRotation;
                } 
                if (i == 6)
                {
                    _cameraTransform.localPosition = rightLookPosition;
                    _cameraTransform.localEulerAngles = rightLookRotation;
                } 
                if (i == 7)
                {
                    _cameraTransform.localPosition = leftLookPosition;
                    _cameraTransform.localEulerAngles = leftLookRotation;
                }
            }
        }
        
        


        var steerInput = _logitechSimple.xAxes;
        var gasInput = _logitechSimple.GasInput;
        var breakInput = _logitechSimple.BreakInput;

        if (gasInput > 0)
        {
            // Accelerate
            transform.Translate(0, 0, 0.1f);
            
            if (steerInput > 0)
            {
                // Turn right
                transform.Rotate(0, steerInput * 10, 0);
            }
            else if (steerInput < 0)
            {
                // Turn left
                transform.Rotate(0, steerInput * 10, 0);
            }
        }

        
        if (breakInput > 0)
        {
            // Brake
            transform.Translate(0, 0, -0.1f);
        }
        
        
        if (Input.GetKeyDown(KeyCode.JoystickButton4) && _currentGear < _maxGears)
        {
            _currentGear++;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton5) && _currentGear > 1)
        {
            _currentGear--;
        }
    }
}
