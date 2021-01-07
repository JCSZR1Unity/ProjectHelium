using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    public float MovementSpeed = 12f; // Movement speed
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f; // Radius of the sphere used to check for the ground.
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Creates tiny invisible sphere around groundCheck object and check for colision.

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Could be 0, but it works better with small amount like that, due to a fact that isGrounded can be registered before we totally on the ground.
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Time.deltaTime is here to make it framerate independent.
        Controller.Move(move * MovementSpeed * Time.deltaTime);

        // Jumping logic.
        // Equation for jumping physics: v = square of (h * -2 * g)
        if (Input.GetButtonDown("Jump") && isGrounded) // Jump - space by default
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime; // Gravity

        Controller.Move(velocity * Time.deltaTime); // It has to be multiplayed by deltaTime again due to a mathematical equation.

    }
}
