using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    
    // First person player object, linked in the unity component view (of this script)
    public Transform PlayerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // We need that so when we look around cursor will not float all over the screen.
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse X - preprogrammed axis, can be found in: Unity -> Edit -> Project Settings -> Input Manager
        // Time.deltaTime - amount of time that gone by since the last time Update function was called. We're adding this to prevent change of move speed depending on our framerate (so it won't be that higher framerate = quicker movement)
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // We're using Quaternion here instead of just .Rotate to also present clamping (preventing camera to rotate further than 180 degree)

        PlayerBody.Rotate(Vector3.up * mouseX); // That makes possible to look around Y axes (from left to right by rotating)
    }
}
