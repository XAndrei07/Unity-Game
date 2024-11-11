using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public PlayerInputActions playerControls;
    private Vector2 moveDirection;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //processing inputs

        moveDirection = move.ReadValue<Vector2>();
    }

    void Move()
    {
         rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void FixedUpdate()
    {
        //physics calculations
        Move();
        
	    if (moveDirection != Vector2.zero) 
	    {
		  float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		  rb.rotation = angle;
	    }
    }
    
}
