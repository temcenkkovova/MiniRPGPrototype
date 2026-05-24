

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  private PlayerController input;
  private PlayerMovement movement;

  private PlayerAttackManager playerAttackManager;


  void Awake()
  {
    input = new PlayerController();
    movement = GetComponent<PlayerMovement>();
    playerAttackManager = GetComponent<PlayerAttackManager>();

  }

  void Update()
  {
    Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();
    if (movement != null) movement.Move(inputVector);
  }

  void OnEnable()
  {
    input.Enable();
    input.Player.Sprint.started += OnSprintStarted;
    input.Player.Sprint.canceled += OnSprintCanceled;
    input.Player.Attack.performed += OnAttackStarted;
  }
  public void OnDisable()
  {
    input.Disable();
    input.Player.Sprint.started -= OnSprintStarted;
    input.Player.Sprint.canceled -= OnSprintCanceled;
    input.Player.Attack.performed -= OnAttackStarted;
  }

  public void OnSprintStarted(InputAction.CallbackContext context)
  {
    movement.ChangeSprintState(true);
  }
  public void OnSprintCanceled(InputAction.CallbackContext context)
  {
    movement.ChangeSprintState(false);
  }
  public void OnAttackStarted(InputAction.CallbackContext context)
  {
    playerAttackManager.ManageAttack();
  }
}