using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    public float MovementSpeed = 12f; // Movement speed

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Time.deltaTime is here to make it framerate independent.
        Controller.Move(move * MovementSpeed * Time.deltaTime);
    }
}
