
using UnityEngine;
using UnityEngine.InputSystem;

// Controls player movement using the arrow keys.
public class PlayerMovement : MonoBehaviour
{
    // Player movement speed, adjustable in the Inspector.
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;
    private InputAction moveAction;

    void Awake()
    {
        // Get the player's physics component.
        rb = GetComponent<Rigidbody2D>();

        // Configure movement using the four arrow keys.
        moveAction = new InputAction("Move", InputActionType.Value);

        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
    }

    void OnEnable()
    {
        // Enable movement input.
        moveAction.Enable();
    }

    void OnDisable()
    {
        // Disable movement input.
        moveAction.Disable();
    }

    void FixedUpdate()
    {
        // Read input and move the player using physics.
        Vector2 direction = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = direction * speed;
    }

    void OnDestroy()
    {
        // Release input resources.
        moveAction.Dispose();
    }
}
