using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction fire;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        fire.Disable();
    }
    private void Fire(InputAction.CallbackContext context){
        gameObject.GetComponent<BoxCollider2D>().enabled=true;
        Invoke("SetFalse",0.1f); //disable collider afte 0.1 s
    }

    private void SetFalse()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
}
