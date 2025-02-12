using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayers;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 movementInput;
    private bool isAttacking, isAttacking2;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        DoMovement();
    }

    public void DoMovement()
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

    public void DoAttack()
    {
        if (isAttacking)
        {
            print("do attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                print($"we hit: {enemy.name}");
            }
        }
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
        isAttacking2 = context.ReadValue<bool>();
        isAttacking2 = context.action.triggered;
        print("Attack 2");
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
