using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public PlayerInputActions playerControls;
    private Vector2 moveDirection;

    private InputAction fire;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //processing inputs

        moveDirection = move.ReadValue<Vector2>();
    }

    private void Fire(InputAction.CallbackContext context){
        //Fireing function
    }
    void Move()
    {
         rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void FixedUpdate()
    {
        //physics calculations
        Move();
    }
    
}
