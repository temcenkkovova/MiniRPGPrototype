

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  private PlayerController input;
  private PlayerMovement movement;

  private PlayerAttackManager playerAttackManager;
  private PlayerInteractionController interactionController;
  public NpcShop npcShop;


  void Awake()
  {
    input = new PlayerController();
    movement = GetComponent<PlayerMovement>();
    playerAttackManager = GetComponent<PlayerAttackManager>();
    interactionController = GetComponent<PlayerInteractionController>();
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
    input.Player.Interact.performed += OnInteractStarted;
    input.Player.Shop.performed += OnShopStarted;
  }
  public void OnDisable()
  {
    input.Disable();
    input.Player.Sprint.started -= OnSprintStarted;
    input.Player.Sprint.canceled -= OnSprintCanceled;
    input.Player.Attack.performed -= OnAttackStarted;
    input.Player.Interact.performed -= OnInteractStarted;
    input.Player.Shop.performed -= OnShopStarted;
  }

  public void OnShopStarted(InputAction.CallbackContext context)
  {
    if (npcShop.ShopStatus())
    {
      npcShop.HandleCloseShop();
    }
    else
    {
      npcShop.HandleOpenShop();
    }

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
  public void OnInteractStarted(InputAction.CallbackContext context)
  {
    interactionController.HandleInteract();
  }
}