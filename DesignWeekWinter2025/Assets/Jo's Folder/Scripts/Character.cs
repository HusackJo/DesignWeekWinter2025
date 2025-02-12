using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 movementInput, aimInput;
    private bool isAttacking, isAttacking2;
    private int whatHandShouldAttack = 0;
    private PlayerInput inputManager;
    private float aimAngle;
    [SerializeField]
    public float playerSpeed = 2.0f;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayers;
    public float attackDelay;
    private float attacktimer;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputManager = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        DoMovement();
    }

    public void DoMovement()
    {
        //
        
        //      Movement

        //
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

        //

        //      Aiming

        //
        if (inputManager.currentControlScheme == "Keyboard")
        {
            //I'd use aiminput if i was smart, but i decided to make this one a vector3
            Vector3 aimDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
            aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        }
        else if (inputManager.currentControlScheme == "Gamepad")
        {
            aimAngle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg - 90f;
        }
        //undoes rotation caused by movement. player is invisible when rotated
        transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, aimAngle);
    }

    public void DoAttack(int whatHandAttacked)
    {
        if (whatHandAttacked == whatHandShouldAttack || whatHandShouldAttack == 0)
        {
            if (Time.time >= attacktimer)
            {
                attacktimer = Time.time + 1f / attackDelay;
                print($"did attack, {attacktimer}");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    print($"we hit: {enemy.name}");
                }
            }
            if (whatHandAttacked == 1)
            {
                whatHandShouldAttack = 2;
            } else if (whatHandAttacked == 2)
            {
                whatHandShouldAttack = 1;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) 
    {
        DoAttack(1);
    }
    public void OnAttack2(InputAction.CallbackContext context)
    {
        DoAttack(2);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
