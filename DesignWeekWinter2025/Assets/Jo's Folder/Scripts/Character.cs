using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 movementInput;
    private bool isAttacking;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move.magnitude > 1)
        {
            gameObject.transform.forward = move.normalized;
        }
        else if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        else
        {
            //not moving
        }

        controller.Move(playerVelocity * Time.deltaTime);

        //undoes rotation caused by movement. player is invisible when rotated
        transform.eulerAngles = Vector3.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) 
    {
        isAttacking = context.ReadValue<bool>();
        isAttacking = context.action.triggered;
        print("Attack 1");
    }
    public void OnAttack2(InputAction.CallbackContext context)
    {
        print("Attack 2");
    }
}
