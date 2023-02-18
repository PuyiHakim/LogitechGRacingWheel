using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    private void Start()
    {
        currentCameraIndex = 0;

        // Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        // If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        // Check if the Logitech G29 button was pressed
        if (Input.GetButtonDown("Camera Switch"))
        {
            // Turn off the currently active camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Switch to the next camera in the array
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Turn on the new active camera
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}
